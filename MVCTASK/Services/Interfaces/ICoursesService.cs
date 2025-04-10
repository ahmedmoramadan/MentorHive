namespace MVCTASK.Services.Interfaces
{
    public interface ICoursesService : IService<Course>
    {
        void Add(AddCourseVM model);
        void Edit(EditCourseVM model);
        List<Course> Search(string name);

    }
}
