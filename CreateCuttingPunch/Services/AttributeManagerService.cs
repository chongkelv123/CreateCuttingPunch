using CreateCuttingPunch.Constants;
using CreateCuttingPunch.Model;
using NXOpen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCuttingPunch.Services
{
    public class AttributeManagerService
    {
        public static string GetAttribute(string Category, string Title)
        {
            var workPart = Session.GetSession().Parts.Work;

            AttributeIterator itr = workPart.CreateAttributeIterator();
            itr.SetIncludeOnlyCategory(Category);
            itr.SetIncludeOnlyTitle(Title);

            var atts = workPart.GetUserAttributes(itr);

            foreach (var att in atts) 
            { 
                if (att.Title == Title)
                    return att.StringValue;
            }

            return null;
        }

        public static ProjectInfoModel RetrieveProjectInfoFrmDrawing()
        {            
            string[] infoList = 
            {
                Const.Attributes.MODEL_NAME,
                Const.Attributes.PART,
                Const.Attributes.DRAWING_CODE,
                Const.Attributes.DESIGNBY
            };

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            infoList.ToList().ForEach(title =>
            {
                var value = GetAttribute(Const.Attributes.CATEGORY_TITLEBLOCK, title);
                if(title == Const.Attributes.DRAWING_CODE)
                {
                    var codePrefix = GetCodePrefix(value);
                    keyValuePairs[Const.ProjectInfo.CODE_PREFIX] = codePrefix;
                }
                else
                {
                    keyValuePairs[title] = value;
                }                    
            });

            return new ProjectInfoModel
            {
                Model = keyValuePairs[Const.Attributes.MODEL_NAME],
                Part = keyValuePairs[Const.Attributes.PART],
                CodePrefix = keyValuePairs[Const.ProjectInfo.CODE_PREFIX],
                Designer = keyValuePairs[Const.Attributes.DESIGNBY]
            };
        }

        private static string GetCodePrefix(string value)
        {
            var codeParts = value.Split('-');
            return codeParts[0] + "-" + codeParts[1] + "-";
        }
    }
}
