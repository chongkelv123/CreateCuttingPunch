using CreateCuttingPunch.Model;
using NXOpen.Features.ShipDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CreateCuttingPunch.Constants.Const;
using NXOpen;
using CreateCuttingPunch.Constants;

namespace CreateCuttingPunch.Services
{
    public class ComponentCreationConfigs
    {
        public static ComponentCreationConfig CreatePunchConfig(
            string folderPath, 
            string fileName,            
            ProjectInfoModel projectInfo,
            string drawingCode, 
            string itemName)
        {
            return new ComponentCreationConfig
            {
                TemplateFileName = NxTemplate.TEMPLATE_3DASTP_NAME,
                PresentationName = NxTemplate.TMP_PRESENTATION_NAME_MODEL,
                UndoDescription = "Create New Punch",
                FolderPath = folderPath,
                FileName = fileName,                
                ProjectInfo = projectInfo,
                DrawingCode = drawingCode,
                ItemName = itemName,
                ColorAssignmentAction = AssignPlateColors,
                PartPropertiesType = PartType.INSERT,
                Material = Const.Material.GOA,
                Hardness = HRC.FIFTYTWO_FIFTYFOUR
            };
        }

        private static void AssignPlateColors(Part workPart, string fileName)
        {
            foreach (Body body in workPart.Bodies)
            {
                body.Color = (int)PunchColor.DARK_HARD_RED;
            }            
        }
    }
}
