using CreateCuttingPunch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CreateCuttingPunch.Constants.Const;
using CreateCuttingPunch.Services;


namespace CreateCuttingPunch.Model
{
    public class Punch
    {
        public string FileName { get; set; }
        public string FolderPath { get; set; }
        public ProjectInfoModel ProjectInfo { get; set; }
        public string DrawingCode { get; set; }
        public string ItemName { get; set; }

        public void Create()
        {
            // Create configuration for this plate            
            var config = ComponentCreationConfigs.CreatePunchConfig(                
                FolderPath,
                FileName,                                                
                ProjectInfo,
                DrawingCode,
                ItemName);

            // Use the unified service to create the component
            var creationService = new ComponentCreationService();
            creationService.CreateNewComponent(config);
        }

    }
}
