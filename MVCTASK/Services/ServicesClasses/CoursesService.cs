namespace MVCTASK.Services.ServicesClasses
{
    public class CoursesService : ICoursesService
    {
        private readonly AppDbContext _context;
        public CoursesService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(AddCourseVM model)
        {
            Course course = new Course()
            {
                Hour = model.Hour,
                Degree = model.Degree,
                MinDegree = model.MinDegree,
                Name = model.Name,
                DepartmentId = model.DepartmentId,
            };
            _context.Add(course);
        }
        public List<SelectListItem> GetCoursesByDptId(int deptId)
        {
            var courses = _context.courses
                .Where(c => c.DepartmentId == deptId)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            return courses;
        }

        public void delete(int id)
        {
            _context.Remove(GetbyId(id));
        }

        public void Edit(EditCourseVM model)
        {
            var c = GetbyId(model.id);
            if (c == null) return;
            c.Hour = model.Hour;
            c.MinDegree = model.MinDegree;
            c.Degree = model.Degree;
            c.Name = model.Name;
            c.DepartmentId = model.DepartmentId;
            _context.Update(c);
        }

        public List<Course> GetAll() 
        {
            return _context.courses.Include(d => d.Department).ToList();
        }

        public Course GetbyId(int id)
        {
            return _context.courses.Include(d => d.Department).FirstOrDefault(x => x.Id == id)!;
        }

        public int save()
        {
            int c = _context.SaveChanges();
            return c;
        }

        public List<Course> Search(string name)
        {
            return _context.courses.Where(c=>c.Name.Contains(name)).ToList();
        }
    }
}
