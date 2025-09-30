using CreateCuttingPunch.Model;
using NXOpen;
using NXOpen.UF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CreateCuttingPunch.Constants.Const;

namespace CreateCuttingPunch.Services
{
    public class ComponentCreationService
    {
        public void CreateNewComponent(ComponentCreationConfig config)
        {
            Session session = Session.GetSession();
            FileNew fileNew = session.Parts.FileNew();

            // Phase 1: File Setup (common across all components)
            ConfigureFileNew(fileNew, config);

            try
            {
                // Phase 2: File Commit & Basic Setup (common)
                NXObject componentObject = fileNew.Commit();
                Part workPart = session.Parts.Work;
                Part displayPart = session.Parts.Display;
                fileNew.Destroy();
                session.ApplicationSwitchImmediate(NxTemplate.UG_APP_MODELING);

                // Phase 3: Color Assignment (delegated to specific component logic)
                if (config.ColorAssignmentAction != null)
                {
                    config.ColorAssignmentAction(workPart, config.FileName);
                }

                // Phase 4: Part Properties Update (common pattern)
                UpdatePartProperties(config);

                // Phase 5: Sketch generation
                GenerateSketch();

                // Phase 7: Save Operations (common)
                SaveComponent(workPart);
            }
            catch (NXException nxEx) when (nxEx.Message.Contains("File already exists"))
            {
                string message = $"File already exists: {config.FileName}{NxTemplate.EXTENSION}\n\n" +
                               $"Location: {config.FolderPath}\n\n" +
                               "Please:\n" +
                               "• Delete the existing file, or\n" +
                               "• Choose a different output directory, or\n" +
                               "• Modify the project code prefix";

                NXDrawing.ShowMessageBox(message, "File Conflict", NXOpen.NXMessageBox.DialogType.Warning);
                throw new InvalidOperationException($"Cannot create component '{config.FileName}' - file already exists", nxEx);
            }
        }

        private void GenerateSketch()
        {
            Part workPart = Session.GetSession().Parts.Work;
            var ufs = UFSession.GetUFSession();
            //ufs.Sket.CreateSketch();
            //ufs.Curve.AskProjCurves();
            
            DatumPlane datumPlane = AskXYDatumPlane();

        }

        private DatumPlane AskXYDatumPlane()
        {
            Part workPart = Session.GetSession().Parts.Work;
            DatumPlane result;

            foreach (DatumPlane datum in workPart.Datums)
            {
                if (
                    datum.Normal.X == 0 && 
                    datum.Normal.Y == 0 &&
                    datum.Normal.Z == 1)
                {
                    NXDrawing.ShowMessageBox($"Name of datum: {datum.Name}", "Datum Info", NXMessageBox.DialogType.Information);
                    return datum;
                }
                
            }

            return null;
        }

        private void SaveComponent(Part workPart)
        {
            BasePart.SaveComponents saveComponentParts = BasePart.SaveComponents.True;
            BasePart.CloseAfterSave close = BasePart.CloseAfterSave.True;
            workPart.Save(saveComponentParts, close);
        }

        private void UpdatePartProperties(ComponentCreationConfig config)
        {
            Part workPart = Session.GetSession().Parts.Work;
            TitleBlockProperties properties = new TitleBlockProperties(
                workPart,
                config.ProjectInfo.Designer,
                config.DrawingCode,
                config.Hardness,
                config.ItemName,
                config.Length,
                config.Thickness,
                config.Width,
                config.Material,
                config.ProjectInfo.Model,
                config.ProjectInfo.Part
                );
            var attrList = properties.AttributeInfoToList(Constants.Const.Attributes.CATEGORY_TITLEBLOCK, properties.Properties);
            properties.SetAttributesByList(attrList);

            NXObject.AttributeInformation info = new NXObject.AttributeInformation();
            info.Category = Constants.Const.Attributes.CATEGORY_TOOL;
            info.Title = Constants.Const.Attributes.PART_TYPE;
            info.Type = NXObject.AttributeType.String;
            info.StringValue = config.PartPropertiesType;
            properties.SetAttribute(info);
        }

        private void ConfigureFileNew(FileNew fileNew, ComponentCreationConfig config)
        {
            fileNew.TemplateFileName = config.TemplateFileName;
            fileNew.UseBlankTemplate = false;
            fileNew.ApplicationName = Constants.Const.NxTemplate.MODEL_TEMPLATE;
            fileNew.Units = Part.Units.Millimeters;
            fileNew.TemplatePresentationName = config.PresentationName;
            fileNew.SetCanCreateAltrep(false);
            fileNew.NewFileName = $"{config.FolderPath}{config.FileName}{Constants.Const.NxTemplate.EXTENSION}";
            fileNew.MakeDisplayedPart = true; // or false, need test
            fileNew.DisplayPartOption = NXOpen.DisplayPartOption.AllowAdditional;
        }
    }
}
