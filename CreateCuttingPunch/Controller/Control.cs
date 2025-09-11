using CreateCuttingPunch.Model;
using CreateCuttingPunch.Services;
using CreateCuttingPunch.View;
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

        public void Start()
        {
            
        }
    }
}
