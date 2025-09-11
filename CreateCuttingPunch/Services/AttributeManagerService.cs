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
    }
}
