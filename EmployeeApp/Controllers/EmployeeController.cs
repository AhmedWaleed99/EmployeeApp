using EmployeeApp.Models;
using EmployeeApp.Repository;
using EmployeeApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public EmployeeController(IEmployeeRepository employeeRepository , IDepartmentRepository departmentRepository , UserManager<ApplicationUser> userManager)
        {
            this.employeeRepository = employeeRepository;
            this.departmentRepository = departmentRepository;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            if (user.DepartmentID == 2)
            {
                return View(employeeRepository.GetAllWithDepartment());
            }
            return View(employeeRepository.GetAllWithDepartmentByID(user.DepartmentID));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            EmployeeViewModel model = new EmployeeViewModel();
            var user = await userManager.GetUserAsync(User);
            if (user.DepartmentID == 2)
            {
                model.Departments = departmentRepository.GettAll();
                return View(model);
            }
            model.Departments = departmentRepository.GetAllByID(user.DepartmentID);
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(EmployeeViewModel model)
        {
            if (ModelState.IsValid==true)
            {
                Employee employee = new Employee();
                employee.Name = model.Name;
                employee.Address = model.Address;
                employee.Phone = model.Phone; 
                employee.Salary = model.Salary; 
                employee.Status = model.Status; 
                employee.DepartmentID = model.DepartmentID;
                employeeRepository.Add(employee);
                employeeRepository.Save();
                return RedirectToAction("Index");
                
            }
            model.Departments = departmentRepository.GettAll();
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles ="Admin,HR")]
        public IActionResult Edit(int id)
        {
            Employee emp = employeeRepository.GetById(id);
            if (emp != null)
            {
               EmployeeViewModel model = new EmployeeViewModel();
            model.Name = emp.Name;
            model.Address = emp.Address;
            model.Phone = emp.Phone;
            model.Salary = emp.Salary;
            model.Status = emp.Status;
            model.DepartmentID = emp.DepartmentID;
            model.Departments = departmentRepository.GettAll();
            return View(model); 
            }
            return NotFound();
            
        }
        [HttpPost]
        [Authorize(Roles = "Admin,HR")]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                Employee employee = employeeRepository.GetById(model.ID);
                employee.Name = model.Name;
                employee.Address = model.Address;
                employee.Phone = model.Phone;
                employee.Salary = model.Salary;
                employee.Status = model.Status;
                employee.DepartmentID = model.DepartmentID;
                employeeRepository.Update(employee);
                employeeRepository.Save();
                return RedirectToAction("Index");

            }
            model.Departments = departmentRepository.GettAll();
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin,HR")]
        public IActionResult Delete(int id)
        {
            
            employeeRepository.Delete(id);
            employeeRepository.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            return View(employeeRepository.GetAllInformation(id));
        }
    }
}
