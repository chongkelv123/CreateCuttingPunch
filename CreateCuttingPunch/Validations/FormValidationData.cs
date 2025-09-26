using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCuttingPunch.Validations
{
    /// <summary>
    /// Form Validation Data
    /// </summary>
    public class FormValidationData
    {
        // Path
        public string Path { get; set; }

        // Numerical Dimension
        public string PunchLength { get; set; }

        // Project Information
        public string Model { get; set; }
        public string Part { get; set; }
        public string CodePrefix { get; set; }
        public string Designer { get; set; }

        // Assembly drawing selected
        public string AsmDrawingPath { get; set; }

        // Profile selection
        public bool IsProfileSelected { get; set; }
    }
}
