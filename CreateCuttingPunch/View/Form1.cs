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
            _selectionService.Selection();
            this.Show();
        }
    }
}
