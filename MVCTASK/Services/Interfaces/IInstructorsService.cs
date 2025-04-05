using MVCTASK.Models;
using MVCTASK.ViewModels.instractorVM;

namespace MVCTASK.Services.Interfaces
{
    public interface IInstructorsService
    {
        Instructor? GetById(int id);
        Task<List<Instructor>> GetAll();
        Task<bool> Add(AddInstVM model);
        bool Remove(int id);
        Task<Instructor> Edit(EditInstVm model);
        IEnumerable<Instructor> GetInstructorsByPage(int num, out int totalPages , out int n);
    }
}
