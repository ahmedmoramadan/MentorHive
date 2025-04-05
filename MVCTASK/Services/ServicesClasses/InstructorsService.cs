using MVCTASK.Data;
using MVCTASK.Models;
using MVCTASK.Services.Interfaces;
using MVCTASK.Services.ServicesFile;
using MVCTASK.Settings;
using MVCTASK.ViewModels.instractorVM;

namespace MVCTASK.Services.ServicesClasses
{
    public class InstructorsService : IInstructorsService
    {
        private readonly AppDbContext _context;
        private readonly FileService _fileService;
        public InstructorsService(AppDbContext context , IWebHostEnvironment webHostEnvironment , FileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }
        public IEnumerable<Instructor> GetInstructorsByPage(int num, out int totalPages , out int n)
        {
            num = (num <= 0) ? 1 : num;
            int len = _context.instructors.Count();
            if ((len <= (num - 1) * 6))
            {
                num = 1;
            }
            else if (num < 0)
            {
                num = (len % 6 == 0) ? len / 6 : len / 6 + 1;
            }

            n = num;
            totalPages = (len % 6 == 0) ? len / 6 : len / 6 + 1;

            return _context.instructors.Skip((num - 1) * 6).Take(6).ToList();
        }
        public async Task<bool> Add(AddInstVM model)
        {
            var CoverName = await _fileService.SaveCoverAsync(model.Img);
            Instructor instractor = new Instructor()
            {
                Name = model.Name,
                Address = model.Address,
                Salary = model.Salary,
                Img = CoverName,
                CrsId = model.CrsId,
                DepartmentId = model.DepartmentId,
            };
            await _context.AddAsync(instractor);
            var er = await _context.SaveChangesAsync();
            return er > 0;
        }

        public async Task<Instructor> Edit(EditInstVm model)
        {
            var inst = GetById(model.id);
            if (inst == null) return null!;
            var NewImg = model.Img != null;
            var oldImg = inst.Img;
            if(oldImg == null) return null!;
            inst.Name = model.Name;
            inst.Address = model.Address;
            inst.Salary = model.Salary;
            inst.CrsId = model.CrsId;
            inst.DepartmentId = model.DepartmentId;
            if (NewImg)
            {
                inst.Img = await _fileService.SaveCoverAsync(model.Img!);
            }
            int ER =await _context.SaveChangesAsync();
            if (ER > 0) 
            {
                if (NewImg)
                {
                    _fileService.DeleteCover(oldImg);
                }
                return inst;
            }
            else
            {
                _fileService.DeleteCover(inst.Img);
                return null!;
            }
        }

        public Task<List<Instructor>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Instructor? GetById(int id)
        {
            return _context.instructors.SingleOrDefault(x => x.Id == id);
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

    }
}
