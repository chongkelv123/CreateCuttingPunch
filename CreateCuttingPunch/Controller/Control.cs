using CreateCuttingPunch.Model;
using CreateCuttingPunch.Services;
using CreateCuttingPunch.View;
using NXOpen;
using NXOpen.UF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCuttingPunch.Controller
{
    public class Control
    {
        NXDrawing drawing;
        UserForm myForm;

        public NXDrawing GetDrawing => drawing;
        public UserForm GetForm => myForm;

        public Control()
        {
            drawing = new NXDrawing(this);

            myForm = new UserForm(this);
            myForm.Show();
        }

        public void Start(SelectionModel selectionModel)
        {
            Punch newPunch = new Punch();
            newPunch.FileName = "Test New Punch";
            newPunch.FolderPath = "C:\\CreateFolder\\TestNewPunches\\";
            newPunch.ProjectInfo = myForm.GetProjectInfo();
            newPunch.DrawingCode = "123456-2401-0111";
            newPunch.ItemName = "New Punch";

            newPunch.Create();
        }
    }
}
