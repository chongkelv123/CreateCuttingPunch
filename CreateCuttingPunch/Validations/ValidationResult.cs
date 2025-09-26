using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCuttingPunch.Validations
{
    /// <summary>
    /// Validation result container
    /// </summary>
    public class ValidationResult
    {
        public bool IsValid { get; set; }        
        public List<string> Errors { get; set; } = new List<string>();
        public void AddError(string error)
        {
            IsValid = false;
            Errors.Add(error);
        }
    }
}
