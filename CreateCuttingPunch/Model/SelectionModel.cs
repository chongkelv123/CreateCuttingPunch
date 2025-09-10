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
        public TaggedObject SketchObject { get; set; }
        public TaggedObject FaceObject { get; set; }
    }
}
