using NXOpen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCuttingPunch.Model
{
    public class SelectionDatumModel
    {
        public TaggedObject DatumObject { get; set; }

        public SelectionDatumModel()
        {
            DatumObject = new TaggedObject();
        }

        public bool IsSelected()
        {
            if (DatumObject == null)
                return false;

            return true;
        }
    }
}
