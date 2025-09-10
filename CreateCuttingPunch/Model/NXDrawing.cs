using CreateCuttingPunch.Controller;
using NXOpen;
using NXOpen.Annotations;
using NXOpen.CAE.Connections;
using NXOpen.Features;
using NXOpen.UF;
using NXOpenUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateCuttingPunch.Model
{
    public enum FaceColor
    {
        WCSP = 55,
        MILL = 211,
        WC = 181,
    }
    public class NXDrawing
    {
        Session session;
        Part workPart;
        UI ui;
        UFSession ufs;
        Controller.Control control;


        public NXDrawing()
        {
        }

        public NXDrawing(Controller.Control control)
        {
            session = Session.GetSession();
            ufs = UFSession.GetUFSession();
            workPart = session.Parts.Work;
            ui = UI.GetUI();


            this.control = control;
        }

        public static void ShowMessageBox(string message, string title, NXMessageBox.DialogType msgboxType)
        {
            UI ui = UI.GetUI();
            ui.NXMessageBox.Show(title, msgboxType, message);
        }

    }
}
