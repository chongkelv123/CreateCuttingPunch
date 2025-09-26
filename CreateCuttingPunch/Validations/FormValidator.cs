using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCuttingPunch.Validations
{
    /// <summary>
    /// Extracts validations logic from forms to improve separation of concerns
    /// </summary>
    public class FormValidator
    {
        private readonly List<string> _requiredFieldsForApply = new List<string>
        {
            nameof(FormValidationData.Path),
            nameof(FormValidationData.PunchLength),
            nameof(FormValidationData.Model),
            nameof(FormValidationData.Part),
            nameof(FormValidationData.CodePrefix),
            nameof(FormValidationData.Designer),
            nameof(FormValidationData.AsmDrawingPath)
        };

        /// <summary>
        /// Validate all form inputs for enabling Apply button
        /// </summary>
        public ValidationResult ValidateForApply(FormValidationData data)
        {
            var result = new ValidationResult
            {
                IsValid = true
            };

            // Validate profile selection
            if(!data.IsProfileSelected)
            {
                result.Errors.AddRange(new List<string> { "Profile selection is required" });
                result.IsValid = false;
            }

            // Validate input information
            var inputFieldsValidation = ValidateInputField(data);
            if (!inputFieldsValidation.IsValid)
            {
                result.Errors.AddRange(inputFieldsValidation.Errors);
                result.IsValid = false;
            }

            // Validate Path
            var pathValidation = ValidatePath(data.Path);
            if (!pathValidation.IsValid)
            {
                result.Errors.AddRange(pathValidation.Errors);
                result.IsValid = false;
            }

            return result;
        }

        private ValidationResult ValidatePath(string path)
        {
            var result = new ValidationResult
            {
                IsValid = true
            };

            if (string.IsNullOrEmpty(path))
            {
                result.AddError("Project directory is required");
                return result;
            }

            if (!Directory.Exists(path))
            {
                result.AddError($"Project directory does not exist: {path}");
                return result;
            }
            return result;
        }

        private ValidationResult ValidateInputField(FormValidationData data)
        {
            var result = new ValidationResult
            {
                IsValid = true
            };

            foreach (var fieldName in _requiredFieldsForApply)
            {
                var value = GetFieldValue(data, fieldName);
                if (string.IsNullOrEmpty(value))
                {
                    result.AddError($"{fieldName} is required");
                    continue;
                }
            }

            return result;
        }

        private string GetFieldValue(FormValidationData data, string fieldName)
        {
            var propoerty = typeof(FormValidationData).GetProperty(fieldName);
            return propoerty?.GetValue(data) as string ?? string.Empty;

        }
    }
}
