using System.ComponentModel.DataAnnotations;

namespace MVCTASK.Validation
{
    public class MaxSizeAttribute : ValidationAttribute
    {
        private readonly int _maxsize;
        public MaxSizeAttribute(int allowedSize)
        {
            _maxsize = allowedSize;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            { 
                if (file.Length > _maxsize)
                {
                    return new ValidationResult($"maximum allowed size is {_maxsize} bytes");
                }
            }
            return ValidationResult.Success;
        }
    }
}
