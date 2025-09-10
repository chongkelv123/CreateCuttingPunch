using CreateCuttingPunch.Controller;
using CreateCuttingPunch.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateCuttingPunch.View
{
    public partial class UserForm : System.Windows.Forms.Form
    {
        Controller.Control control;
        private readonly SelectionServices _selectionService;

        public string GetPath => txtPath.Text.Trim();
        public string GetModel => txtModel.Text.Trim();
        public string GetPart => txtPart.Text.Trim();
        public string GetCodePrefix => txtCodePrefix.Text.Trim();
        public string GetDesigner => cboDesign.SelectedItem?.ToString().Trim() ?? string.Empty;

        public UserForm(Controller.Control control)
        {
            InitializeComponent();
            this.control = control;
            _selectionService = new SelectionServices();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
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
    }
}
