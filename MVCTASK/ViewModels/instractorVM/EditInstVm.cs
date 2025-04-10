using MVCTASK.Settings;
using MVCTASK.Validation;

namespace MVCTASK.ViewModels.instractorVM
{
    public class EditInstVm :InstVM
    {
         public int id {  get; set; } 
        public string CuruntImg { get; set; } = string.Empty;
        [MaxSize(FileSetitings.maxSizeByByets)]
        [AllowedExtention(FileSetitings.AllowExtentions)]
        public IFormFile? Img { get; set; } = default!;

    }
}
