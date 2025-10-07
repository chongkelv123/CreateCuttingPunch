using CreateCuttingPunch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen;
using static CreateCuttingPunch.Constants.Const;

namespace CreateCuttingPunch.Services
{
    public class ComponentCreationConfig
    {
        public string TemplateFileName { get; set; }
        public string PresentationName { get; set; }
        public string UndoDescription { get; set; }
        public string FolderPath { get; set; }
        public string FileName { get; set; }        
        public ProjectInfoModel ProjectInfo { get; set; }
        public string DrawingCode { get; set; }
        public string ItemName { get; set; }
        public Action<Part, string> ColorAssignmentAction { get; set; }
        public string PartPropertiesType { get; set; } = PartType.INSERT;
        public string Material { get; set; } = Constants.Const.Material.DC53;
        public string Hardness { get; set; } = HRC.FIFTYEIGHT_SIXTY;
        public string Width { get; set; } = HRC.HYPHEN;
        public string Length { get; set; } = HRC.HYPHEN;
        public string Thickness { get; set; } = HRC.HYPHEN;        
        public TaggedObject SheetObject { get; set; }
    }
}
