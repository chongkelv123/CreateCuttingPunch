using NXOpen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CreateCuttingPunch.Constants.Const;
using static NXOpen.Motion.HydrodynamicBearingBuilder;


namespace CreateCuttingPunch.Model
{    
    public class TitleBlockProperties
    {
        private string designBy;
        private string drawingCode;
        private string hrc;
        private string itemName;
        private string length;
        private string thickness;
        private string width;
        private string material;
        private string modelName;
        private string partName;
        private string quantity;

        public Dictionary<string, string> Properties { get; set; }

        public TitleBlockProperties(Part workPart, string designBy, string drawingCode, string hrc, string itemName, string length, string thickness, string width, string material, string modelName, string partName, string quantity = "1")
        {
            this.designBy = designBy;
            this.drawingCode = drawingCode;
            this.hrc = hrc;
            this.itemName = itemName;
            this.length = length;
            this.thickness = thickness;
            this.width = width;
            this.material = material;
            this.modelName = modelName;
            this.partName = partName;
            this.quantity = quantity;

            GenerateKeyValue_Info();
        }

        private void GenerateKeyValue_Info()
        {            
            var properties = new Dictionary<string, string>()
            {
                {Constants.Const.Attributes.MODEL_NAME, modelName },
                {Constants.Const.Attributes.PART, partName},
                {Constants.Const.Attributes.ITEM_NAME, itemName},
                {Constants.Const.Attributes.DRAWING_CODE, drawingCode},
                {Constants.Const.Attributes.MATERIAL, material},
                {Constants.Const.Attributes.HRC, hrc},
                {Constants.Const.Attributes.QUANTITY, quantity },
                {Constants.Const.Attributes.DESIGNBY, designBy},
                {Constants.Const.Attributes.THICKNESS, thickness },
                {Constants.Const.Attributes.WIDTH, width },
                {Constants.Const.Attributes.LENGTH, length },
                {Constants.Const.Attributes.DESIGN_DATE, DateTime.Now.ToString("dd MMM yyyy") }
            };

            Properties = properties;
        }

        public List<NXObject.AttributeInformation> AttributeInfoToList(string category, Dictionary<string, string> titleInfos)
        {
            List<NXObject.AttributeInformation> result = new List<NXObject.AttributeInformation>();
            foreach (var titleInfo in titleInfos)
            {
                NXObject.AttributeInformation info = new NXObject.AttributeInformation();

                if (titleInfo.Value.Equals("TRUE"))
                {
                    info.Type = NXObject.AttributeType.Boolean;
                    info.BooleanValue = true;
                }
                else
                {
                    info.Type = NXObject.AttributeType.String;
                    info.StringValue = titleInfo.Value;
                }

                info.Category = category;
                info.Title = titleInfo.Key;

                result.Add(info);
            }

            return result;
        }

        public void SetAttributesByList(List<NXObject.AttributeInformation> attributes)
        {
            try
            {
                attributes.ForEach(a => { Session.GetSession().Parts.Work.SetUserAttribute(a, Update.Option.Now); });
            }
            catch (Exception e)
            {
                string message = $"Error occur at TitleBlockProperties: {e.Message}";
                NXDrawing.ShowMessageBox(message, "ERROR", NXMessageBox.DialogType.Error);
            }
        }

        public void SetAttribute(NXObject.AttributeInformation info)
        {
            Session.GetSession().Parts.Work.SetUserAttribute(info, Update.Option.Now);
        }
    }
}
