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
            //System.Diagnostics.Debugger.Launch();
            var sheetBody = selectionModel.SheetBodyObject;
            Body body = sheetBody[0] as Body;
            var edges = body.GetEdges();

            // Sketch builder
            Part workPart = Session.GetSession().Parts.Work;
            Sketch nullSketch = null;
            SketchInPlaceBuilder skBuilder = workPart.Sketches.CreateSketchInPlaceBuilder2(nullSketch);

            NXOpen.Point3d origin1 = new NXOpen.Point3d(0.0, 0.0, 76.0);
            NXOpen.Vector3d normal1 = new NXOpen.Vector3d(0.0, 0.0, 1.0);
            NXOpen.Plane plane1;
            plane1 = workPart.Planes.CreatePlane(origin1, normal1, NXOpen.SmartObject.UpdateOption.WithinModeling);

            skBuilder.PlaneReference = plane1;


        }
    }
}
