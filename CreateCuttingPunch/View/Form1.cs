using CreateCuttingPunch.Constants;
using CreateCuttingPunch.Controller;
using CreateCuttingPunch.Model;
using CreateCuttingPunch.Services;
using CreateCuttingPunch.Validations;
using NXOpen;
using NXOpen.CAE.Xyplot;
using NXOpen.Features;
using NXOpen.Routing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateCuttingPunch.View
{
    public partial class UserForm : System.Windows.Forms.Form
    {
        Controller.Control control;
        private readonly SelectionServices _selectionService;
        private readonly FormValidator _validator;
        private SelectionModel selectionModel;
        private TaggedObject sheetObject;

        bool showDebugMessage = false;

        public string GetPunchLength => txtPunchLength.Text.Trim();
        public string TextPath
        {
            get => txtPath.Text.Trim() + "\\";
            set => txtPath.Text = value;
        }
        public string TextModel
        {
            get => txtModel.Text.Trim();
            set => txtModel.Text = value;
        }
        public string TextPart
        {
            get => txtPart.Text.Trim();
            set => txtPart.Text = value;
        }
        public string TextCodePrefix
        {
            get => txtCodePrefix.Text.Trim();
            set => txtCodePrefix.Text = value;
        }
        public string TextAsmDrawingPath
        {
            get
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    var selectedItem = listView1.SelectedItems[0];
                    var fullPath = selectedItem.Tag?.ToString();
                    return fullPath;
                }
                return string.Empty;
            }
        }


        public string TextDesigner
        {
            get => cboDesign.Text.Trim();
            set => cboDesign.Text = value;
        }

        public string TextPunLength
        {
            get => txtPunchLength.Text.Trim();
            set => txtPunchLength.Text = value;
        }

        public string TextTipLength
        {
            get => txtTipLength.Text.Trim();
            set => txtTipLength.Text = value;
        }

        public string GetSubAsmName
        {            
            get => listView1.SelectedItems[0].Text;
        }

        public string GetSubAsmPath
        {
            get => listView1.SelectedItems[0].Tag?.ToString();
        }        

        public TaggedObject GetSheetObject
        {
            get => sheetObject;
        }

        public ProjectInfoModel GetProjectInfo()
        {
            return new ProjectInfoModel()
            {
                Model = TextModel,
                Part = TextPart,
                CodePrefix = TextCodePrefix,
                Designer = TextDesigner
            };
        }

        public UserForm(Controller.Control control)
        {
            InitializeComponent();
            this.control = control;
            _selectionService = new SelectionServices();
            _validator = new FormValidator();
            selectionModel = new SelectionModel();

            TextPunLength = AttributeManagerService.GetAttribute(
                Const.Attributes.CATEGORY_TOOLINGINFO,
                Const.Attributes.PUNCH_LENGTH
                );
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            control.Start(selectionModel);
            this.Close();
        }

        private void btnSelectSketch_Click(object sender, EventArgs e)
        {
            this.Hide();

            selectionModel = _selectionService.Selections();
            UpdateSelectLableStatus(selectionModel.IsSelected(), lblSketchStatus);
            sheetObject = selectionModel.SheetBodyObject[0];
            UpdateApplyButtonStage();

            this.Show();
        }

        private void UpdateSelectLableStatus(bool isSelected, Label label)
        {
            const string NO_SKETCH_SELECTED = "No sketch selected";
            string updateStatusText = $"Object selected";

            if (isSelected)
            {
                label.Text = updateStatusText;
                label.ForeColor = Color.Green;
            }
            else
            {
                label.Text = NO_SKETCH_SELECTED;
                label.ForeColor = Color.Red;
            }
        }

        private static void KeyPressEvent_NumericalOnly(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (e.g., backspace), digits, and optionally a single decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ignore the input
            }

            // Only allow one decimal point
            if (e.KeyChar == '.' && (sender as System.Windows.Forms.TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void chkRetriveProjInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRetriveProjInfo.Checked)
            {
                UpdateProjectInfo();
            }
            else
            {
                ClearProjectInfo();
            }
        }

        private void ClearProjectInfo()
        {
            TextPart = string.Empty;
            TextModel = string.Empty;
            TextCodePrefix = string.Empty;
            TextDesigner = string.Empty;
        }

        private void UpdateProjectInfo()
        {
            var projInfo = ProjectInfoService.ReadFromFile();
            TextPart = projInfo.Part;
            TextModel = projInfo.Model;
            TextCodePrefix = projInfo.CodePrefix;
            TextDesigner = projInfo.Designer;
        }

        private void btnSaveProjInfo_Click(object sender, EventArgs e)
        {
            UpdateProjectInfoToFile();
        }

        private void UpdateProjectInfoToFile()
        {
            if (!IsProjectInfoFilled())
            {
                string message = "Please fill in all project information fields before saving.";
                string title = "Incomplete Information";
                NXDrawing.ShowMessageBox(message, title, NXMessageBox.DialogType.Error);
                return;
            }

            List<string> info = new List<string>()
            {
                TextModel,
                TextPart,
                TextCodePrefix,
                TextDesigner
            };

            ProjectInfoService.WriteToFile(info);
        }

        private bool IsProjectInfoFilled()
        {
            return
                !string.IsNullOrEmpty(TextModel) &&
                !string.IsNullOrEmpty(TextCodePrefix) &&
                !string.IsNullOrEmpty(TextDesigner) &&
                !string.IsNullOrEmpty(TextDesigner);
        }

        private void btnPathRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                Part workPart = Session.GetSession().Parts.Work;
                TextPath = FileManageService.GetCurrentDirectory(workPart);

                // Populate ListView with assembly files
                PopulateAssemblyListView();
            }
            catch (Exception ex)
            {
                string message = $"Error retrieving path or loading assembly files: {ex.Message}";
                string title = "Error";
                NXDrawing.ShowMessageBox(message, title, NXMessageBox.DialogType.Error);
            }
        }

        private void PopulateAssemblyListView()
        {
            try
            {
                // Clear existing items
                listView1.Items.Clear();

                // Check if path is valid
                if (string.IsNullOrEmpty(TextPath) || !Directory.Exists(TextPath))
                {
                    return;
                }

                // Get assembly files using your service
                var assemblyFiles = FileManageService.GetAssemblyFiles(TextPath);

                // Configure ListView if not already configured
                ConfigureListView();

                // Add files to ListView
                foreach (var filePath in assemblyFiles)
                {
                    var fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
                    var listItem = new ListViewItem(fileName);
                    listItem.Tag = filePath; // Store full path in Tag for later use
                    listView1.Items.Add(listItem);
                }

                // Update status
                UpdateAssemblyListStatus(assemblyFiles.Count);
            }
            catch (Exception ex)
            {
                string message = $"Error loading assembly files: {ex.Message}";
                string title = "Error Loading Files";
                NXDrawing.ShowMessageBox(message, title, NXMessageBox.DialogType.Error);
            }
        }

        private void ConfigureListView()
        {
            // Configure ListView for better appearance
            if (listView1.View != System.Windows.Forms.View.Details)
            {
                listView1.View = System.Windows.Forms.View.Details;
                listView1.FullRowSelect = true;
                listView1.GridLines = true;
                listView1.Sorting = SortOrder.Ascending;

                // Add columns if they don't exist
                if (listView1.Columns.Count == 0)
                {
                    listView1.Columns.Add("Assembly File Name", 300);
                }
            }
        }

        private void UpdateAssemblyListStatus(int fileCount)
        {
            // Update the group box text to show count
            groupBox5.Text = $"Assembly Lists: ({fileCount} files), pick one for the punch";
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                var fileName = selectedItem.Text;
                var fullPath = selectedItem.Tag?.ToString();

                string message = $"Selected Assembly: {fileName}\nFull Path: {fullPath}";
                NXDrawing.ShowMessageBox(message, "Assembly File Selected", NXMessageBox.DialogType.Information);
            }
        }

        private void chkRetriveProjInfoFromDwg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRetriveProjInfoFromDwg.Checked)
            {
                var projInfo = AttributeManagerService.RetrieveProjectInfoFrmDrawing();
                TextModel = projInfo.Model;
                TextPart = projInfo.Part;
                TextDesigner = projInfo.Designer;
                TextCodePrefix = projInfo.CodePrefix;
            }
            else
            {
                ClearProjectInfo();
            }
        }

        private void UpdateApplyButtonStage()
        {
            var validationData = new FormValidationData
            {
                Path = TextPath,
                PunchLength = TextPunLength,
                Model = TextModel,
                Part = TextPart,
                CodePrefix = TextCodePrefix,
                Designer = TextDesigner,
                AsmDrawingPath = TextAsmDrawingPath,
                IsProfileSelected = selectionModel.IsSelected()
            };

            var validationResult = _validator.ValidateForApply(validationData);
            BtnApply.Enabled = validationResult.IsValid;

            if (showDebugMessage && !validationResult.IsValid)
            {
                string message = string.Join(Environment.NewLine, validationResult.Errors);
                string title = "Validation Errors";
                NXDrawing.ShowMessageBox(message, title, NXMessageBox.DialogType.Error);
            }
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            UpdateApplyButtonStage();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateApplyButtonStage();
        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {
            UpdateApplyButtonStage();
        }

        private void txtPart_TextChanged(object sender, EventArgs e)
        {
            UpdateApplyButtonStage();
        }

        private void txtCodePrefix_TextChanged(object sender, EventArgs e)
        {
            UpdateApplyButtonStage();
        }

        private void cboDesign_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateApplyButtonStage();
        }

        private void txtPunchLength_TextChanged(object sender, EventArgs e)
        {
            UpdateApplyButtonStage();
        }

        private void btnSelectDatum_Click(object sender, EventArgs e)
        {
            this.Hide();

            //System.Diagnostics.Debugger.Launch();
            var selectionDatumModel = _selectionService.DatumSelection();
            DatumPlane datumPlane = selectionDatumModel.DatumObject as DatumPlane;

            this.Show();
        }
    }
}
