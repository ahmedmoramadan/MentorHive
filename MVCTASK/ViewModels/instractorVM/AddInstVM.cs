using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCTASK.Settings;
using MVCTASK.Validation;

namespace MVCTASK.ViewModels.instractorVM
{
    public class AddInstVM : InstVM
    {
        [MaxSize(FileSetitings.maxSizeByByets),
        AllowedExtention(FileSetitings.AllowExtentions)]
        //[RegularExpression(@"\w+\.(jpg|jpeg|png)", ErrorMessage = "Only .jpg, .jpeg or .png files are allowed")]
        public IFormFile Img { get; set; } = default!;
    }
}
