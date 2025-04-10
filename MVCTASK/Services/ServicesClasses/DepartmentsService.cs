namespace MVCTASK.Services.ServicesClasses
{
    public class DepartmentsService : IDepartmentsService
    {
        private readonly AppDbContext _Context;
        public DepartmentsService(AppDbContext context)
        {
            _Context = context;
        }
        public IEnumerable<SelectListItem> GetDepartments()
        {
            return _Context.departments.Select(x =>
            new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).OrderBy(x => x.Text).AsNoTracking().ToList();
        }
    }
}
