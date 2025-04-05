using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCTASK.ViewModels.instractorVM
{
    public class AddInstVM : InstVM
    {
        public IFormFile Img { get; set; } = default!;
    }
}
