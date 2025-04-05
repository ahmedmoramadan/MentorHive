namespace MVCTASK.ViewModels.instractorVM
{
    public class EditInstVm :InstVM
    {
         public int id {  get; set; } 
        public string CuruntImg { get; set; } = string.Empty;
        public IFormFile? Img { get; set; } = default!;

    }
}
