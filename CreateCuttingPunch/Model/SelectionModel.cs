using NXOpen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCuttingPunch.Model
{
    public class SelectionModel
    {
        public List<TaggedObject> SketchObject { get; set; }
        public List<TaggedObject> SheetBodyObject { get; set; }        
        public List<Tag> TagCurves;

        public SelectionModel()
        {
            SketchObject = new List<TaggedObject>();
            SheetBodyObject = new List<TaggedObject>();
            TagCurves = new List<Tag>();
        }

        public bool IsSelected()
        {
            if (SketchObject == null && SheetBodyObject == null)
                return false;

            return (
                SketchObject != null && SketchObject.Any()) ||
                (SheetBodyObject != null && SheetBodyObject.Any());

            //if (TagCurves.Count == 0)
            //    return false;

            //return (TagCurves.Count > 0);
        }        
    }
}
