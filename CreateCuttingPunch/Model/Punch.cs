using CreateCuttingPunch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CreateCuttingPunch.Constants.Const;
using NXOpen;


namespace CreateCuttingPunch.Model
{
    public class Punch
    {
        public string FileName { get; set; }
        public string FolderPath { get; set; }
        public ProjectInfoModel ProjectInfo { get; set; }
        public string DrawingCode { get; set; }
        public string ItemName { get; set; }
        public string Length { get; set; }
        public TaggedObject SheetObject { get; set; }

        ComponentCreationConfig getConfig => ComponentCreationConfigs.CreatePunchConfig(
            FolderPath,
            FileName,
            ProjectInfo,
            DrawingCode,
            ItemName,
            Length,
            SheetObject
        );

        public Part Create()
        {
            // Create configuration for this punch            
            var config = getConfig;

            // Use the unified service to create the component
            var creationService = new ComponentCreationService();
            var workPart = creationService.CreateNewComponent(config);

            return workPart;
        }

        public void GenerateProfile()
        {
            var config = getConfig;

            var creationService = new ComponentCreationService();
            creationService.MakeSketchProjectCurve(config);
        }

        public void Extrude(string sketchName = "MAIN")
        {
            var config = getConfig;

            var creationService = new ComponentCreationService();
            creationService.ExtrudeSketchByName(sketchName, config.Length);
        }

    }
}
