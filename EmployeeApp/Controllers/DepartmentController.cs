using EmployeeApp.Models;
using EmployeeApp.Repository;
using EmployeeApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    [Authorize(Roles = "Admin,HR")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            return View(departmentRepository.GettAll());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(DepartmentViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                Department department = new Department();

                department.Name = model.Name;
                department.ManagerName = model.ManagerName;
                department.Status = model.Status;
                departmentRepository.Add(department);

                departmentRepository.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Department department = departmentRepository.GetByID(id);

            if (department != null)
            {
                DepartmentViewModel model = new DepartmentViewModel();
                model.ID = department.ID;
                model.Name = department.Name;
                model.ManagerName = department.ManagerName;
                model.Status = department.Status;
                return View(model);
            }
            return NotFound();
            
        }
        [HttpPost]
        public IActionResult Edit(DepartmentViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                Department department = departmentRepository.GetByID(model.ID);
                department.Name = model.Name;
                department.ManagerName = model.ManagerName;
                department.Status = model.Status;
                departmentRepository.Update(department);

                departmentRepository.Save();
                return RedirectToAction("Index");
            }
            return View(model);


        }
    }
}
