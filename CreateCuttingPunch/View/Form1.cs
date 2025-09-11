using CreateCuttingPunch.Controller;
using CreateCuttingPunch.Model;
using CreateCuttingPunch.Services;
using CreateCuttingPunch.Constants;
using NXOpen;
using NXOpen.CAE.Xyplot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NXOpen.Routing;
using System.IO;

namespace CreateCuttingPunch.View
{
    public partial class UserForm : System.Windows.Forms.Form
    {
        Controller.Control control;
        private readonly SelectionServices _selectionService;        

        public string TextPath 
        {  
            get => txtPath.Text.Trim(); 
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
        
        public string TextDesigner
        {
            get => cboDesign.SelectedItem?.ToString().Trim() ?? string.Empty;
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

        public UserForm(Controller.Control control)
        {
            InitializeComponent();
            this.control = control;
            _selectionService = new SelectionServices();
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
            var asmFiles = FileManageService.GetAssemblyFiles(TextPath);
            string output = string.Empty;
            asmFiles.ForEach(asmFiles => {
                var f = System.IO.Path.GetFileNameWithoutExtension(asmFiles);
                output += f + "\n";
            });
            NXDrawing.ShowMessageBox(output, "List Assembly files", NXMessageBox.DialogType.Information);
            control.Start();
            this.Close();
        }

        private void btnSelectSketch_Click(object sender, EventArgs e)
        {
            this.Hide();

            var selctions = _selectionService.Selections();
            UpdateSelectLableStatus(selctions.IsSelected(), lblSketchStatus);

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
            Part workPart = Session.GetSession().Parts.Work;
            TextPath = FileManageService.GetCurrentDirectory(workPart);            
        }
    }
}
