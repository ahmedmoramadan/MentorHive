namespace MVCTASK.Services.Interfaces
{
    public interface IDepartmentsService
    {
        IEnumerable<SelectListItem> GetDepartments();
    }
}
