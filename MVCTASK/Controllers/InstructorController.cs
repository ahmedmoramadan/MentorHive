﻿using System.Data;


namespace MVCTASK.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorsService _instructorsService;
        private readonly ICoursesService _coursesService;
        private readonly AppDbContext _Context;
        public InstructorController(IInstructorsService instructorsService, AppDbContext context ,ICoursesService coursesService)
        {
            _coursesService = coursesService;
            _instructorsService = instructorsService;
            _Context = context;
        }
        public IActionResult Index(int num)
        {
            int totalpage;
            int n;
            var listinst = _instructorsService.GetInstructorsByPage(num, out totalpage, out n).ToList();
            ViewBag.totalpage = totalpage;
            ViewBag.number = n;
            return View(listinst);
        }
        public IActionResult Details(int id)
        {
            var instructor = _instructorsService.GetById(id);
            return View(instructor);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddInstVM addInstVM = new AddInstVM();
            addInstVM.Departments = _Context.departments.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).OrderBy(x => x.Text).AsNoTracking().ToList();
            addInstVM.Courses = new List<SelectListItem>();
            // addInstVM.Courses = _Context.courses.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).OrderBy(x => x.Text).AsNoTracking().ToList();
            return View(addInstVM);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddInstVM model)
        {
            if (!ModelState.IsValid)
            {
                AddInstVM addInstVM = new AddInstVM();
                addInstVM.Departments = _Context.departments.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).OrderBy(x => x.Text).AsNoTracking().ToList();
                if (model.DepartmentId != 0)
                {
                    model.Courses = _Context.courses
                        .Where(c => c.DepartmentId == model.DepartmentId)
                        .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
                        .OrderBy(x => x.Text)
                        .AsNoTracking()
                        .ToList();
                }
                else
                {
                    model.Courses = new List<SelectListItem>();
                }
                // addInstVM.Courses = _Context.courses.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).OrderBy(x => x.Text).AsNoTracking().ToList();
                return View(addInstVM);
            }
            var result = await _instructorsService.Add(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var inst = _instructorsService.GetById(id);
            EditInstVm editInstVm = new EditInstVm();
            editInstVm.id = inst!.Id;
            editInstVm.Address = inst.Address;
            editInstVm.CrsId = inst.CrsId;
            editInstVm.Name = inst.Name;
            editInstVm.Salary = inst.Salary;
            editInstVm.DepartmentId = inst.DepartmentId;
            editInstVm.CuruntImg = inst.Img;
            editInstVm.Departments = _Context.departments.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).OrderBy(x => x.Text).AsNoTracking().ToList();
            editInstVm.Courses = _Context.courses.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).OrderBy(x => x.Text).AsNoTracking().ToList();
            return View(editInstVm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditInstVm model)
        {
            if (!ModelState.IsValid)
            {
                EditInstVm editInstVm = new EditInstVm();
                editInstVm.Departments = _Context.departments.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).OrderBy(x => x.Text).AsNoTracking().ToList();
                editInstVm.Courses = _Context.courses.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).OrderBy(x => x.Text).AsNoTracking().ToList();
                return View(editInstVm);
            }
            await _instructorsService.Edit(model);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult GetCoursesByDepartment(int deptId)
        {
            var courses = _coursesService.GetCoursesByDptId(deptId);

            return Json(courses);
        }

    }
}
