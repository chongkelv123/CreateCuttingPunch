using CreateCuttingPunch.Model;
using CreateCuttingPunch.Services;
using CreateCuttingPunch.View;
using NXOpen;
using NXOpen.Annotations;
using NXOpen.UF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static CreateCuttingPunch.Constants.Const;
using NXOpen.Assemblies;

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
            Session session = Session.GetSession();
            Part workAssy = session.Parts.Work;
            string mainAsmDisplayName = workAssy.Name;
            NXDrawing.ShowMessageBox(
                $"main asm name: {mainAsmDisplayName}",
                "Testing",
                NXMessageBox.DialogType.Information);

            string punchFileName = "TestNewPunch";
            Punch newPunch = new Punch();
            newPunch.FileName = punchFileName;
            newPunch.FolderPath = myForm.TextPath + "\\";
            newPunch.ProjectInfo = myForm.GetProjectInfo();
            newPunch.DrawingCode = "123456-2401-0111";
            newPunch.ItemName = "Cutting Punch";
            newPunch.SheetObject = myForm.GetSheetObject;

            var punchPart = newPunch.Create();

            string subAsmFullPath = myForm.GetSubAsmPath;

            try
            {
                System.Diagnostics.Debugger.Launch();

                Part targetSubAsmComponent = SetActive(myForm.GetSubAsmName);

                Point3d position = new Point3d(100, 0, 137.55);
                string insertFullPath = Path.Combine(myForm.TextPath, punchFileName);
                ComponentInsertService.Insert(targetSubAsmComponent, punchFileName, position, myForm.TextPath);


                //Part punchComponent = OpenInWindow(punchFileName);
                // Project Curve here
                SetActive(mainAsmDisplayName);
                var punchComponent = GetComponentByName(punchFileName, workAssy);
                session.Parts.SetWorkComponent(punchComponent, out _);
                newPunch.GenerateProfile();

                //ClosePartFile(punchPart);
                //ClosePartFile(targetSubAsmComponent);

                SetActive(mainAsmDisplayName);
            }
            catch (Exception ex)
            {
                throw new Exception($"error open / insert component: {ex.Message}");
            }
        }

        private Component GetComponentByName(string componentName, Part workAssy)
        {
            Component rootComponent = workAssy.ComponentAssembly.RootComponent;

            return FindComponentRecursive(componentName, rootComponent);
        }

        private Component FindComponentRecursive(string componentName, Component parentComponent)
        {
            if (parentComponent.DisplayName.Equals(componentName, StringComparison.OrdinalIgnoreCase))
            {
                return parentComponent;
            }

            foreach (var childComponent in parentComponent.GetChildren())
            {
                var foundComponent = FindComponentRecursive(componentName, childComponent);
                if (foundComponent != null)
                    return foundComponent;
            }
            return null;
        }

        private void ClosePartFile(Part workPart)
        {
            if (workPart == null)
                return;

            try
            {
                workPart.Close(BasePart.CloseWholeTree.True, BasePart.CloseModified.UseResponses, null);
            }
            catch (Exception ex)
            {

                throw new Exception($"Close Part Error: {ex.Message}");
            }
        }

        private Part SetActive(string fileNameWithOutExtension)
        {
            Session session = Session.GetSession();
            Part targetComponent = session.Parts.FindObject(fileNameWithOutExtension) as Part;
            session.Parts.SetActiveDisplay(
                targetComponent,
                DisplayPartOption.AllowAdditional,
                PartDisplayPartWorkPartOption.UseLast,
                out _);
            return targetComponent;
        }
        

        private Component GetComponentByName(string componentName, Component rootComponent)
        {
            string displayName = rootComponent.DisplayName;
            if (displayName.Equals(componentName, StringComparison.OrdinalIgnoreCase))
            {
                return rootComponent;
            }

            foreach (var component in rootComponent.GetChildren())
            {
                GetComponentByName(displayName, component);
            }


            return null;
        }
    }
}
