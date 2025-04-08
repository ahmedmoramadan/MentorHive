using System.ComponentModel.DataAnnotations;
using MVCTASK.Models;

namespace MVCTASK.Validation
{
    public class AllowedExtentionAttribute : ValidationAttribute
    {
        private readonly string _allowedExtention;
        public AllowedExtentionAttribute(string allowedExtention)
        {
            _allowedExtention = allowedExtention;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extention = Path.GetExtension(_allowedExtention);
                var isExtentionValid = _allowedExtention.Split(',').Contains(extention, StringComparer.OrdinalIgnoreCase);
                if (!isExtentionValid)
                {
                    return new ValidationResult($"only {_allowedExtention} are allowed ");
                }
            }
            return ValidationResult.Success;
        }
    }

}


