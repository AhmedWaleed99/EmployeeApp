using EmployeeApp.Models;
using EmployeeApp.Repository;
using EmployeeApp.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    public class EmployeePenaltyController : Controller
    {
        private readonly IEmployeePenalty employeePenaltyRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPenaltyTypeRepository penaltyTypeRepository;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeePenaltyController(IEmployeePenalty employeePenaltyRepository , UserManager<ApplicationUser> userManager , IPenaltyTypeRepository penaltyTypeRepository , IEmployeeRepository employeeRepository)
        {
            this.employeePenaltyRepository = employeePenaltyRepository;
            this.userManager = userManager;
            this.penaltyTypeRepository = penaltyTypeRepository;
            this.employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            return View(employeePenaltyRepository.GetAll());
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            EmployeePenaltyViewModel model = new EmployeePenaltyViewModel();
            var user = await userManager.GetUserAsync(User);
            model.ManagerID = user.Id;
            model.Date = DateTime.Now;
            model.PenaltyTypeList = penaltyTypeRepository.GetAll();
            if (User.IsInRole("HR") | User.IsInRole("Admin")) {
                model.EmployeeList = employeeRepository.GetAll();
            }
            else
            {
                model.EmployeeList = employeeRepository.GetAllWithDepartmentByID(user.DepartmentID);
            }
      
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(EmployeePenaltyViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                EmployeePenalty empen = new EmployeePenalty();
                empen.EmployeeID = model.EmployeeID;
                empen.ManagerID = model.ManagerID;
                empen.PenaltyTypeID = model.PenaltyTypeID;
                empen.Amount = model.Amount;
                empen.Date = model.Date;
                empen.Notes = model.Notes;
                employeePenaltyRepository.Add(empen);
                employeePenaltyRepository.Save();
                return RedirectToAction("Index","Employee");

            }
            var user = await userManager.GetUserAsync(User);
            model.ManagerID = user.Id;
            model.Date = DateTime.Now;
            model.PenaltyTypeList = penaltyTypeRepository.GetAll();
            if (User.IsInRole("HR") | User.IsInRole("Admin"))
            {
                model.EmployeeList = employeeRepository.GetAll();
            }
            else
            {
                model.EmployeeList = employeeRepository.GetAllWithDepartmentByID(user.DepartmentID);
            }
            return View(model);
          
        }
        [HttpGet]
        public async Task<IActionResult> AddPenaltyForEmployee(int id)
        {
            EmployeePenaltyViewModel model = new EmployeePenaltyViewModel();
            var user = await userManager.GetUserAsync(User);
            model.ManagerID = user.Id;
            model.Date = DateTime.Now;
            model.PenaltyTypeList = penaltyTypeRepository.GetAll();
            model.EmployeeList = employeeRepository.GetEmployeeByID(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddPenaltyForEmployee(EmployeePenaltyViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                EmployeePenalty empen = new EmployeePenalty();
                empen.EmployeeID = model.EmployeeID;
                empen.ManagerID = model.ManagerID;
                empen.PenaltyTypeID = model.PenaltyTypeID;
                empen.Amount = model.Amount;
                empen.Date = model.Date;
                empen.Notes = model.Notes;
                employeePenaltyRepository.Add(empen);
                employeePenaltyRepository.Save();
                return RedirectToAction("Index", "Employee");

            }
            var user = await userManager.GetUserAsync(User);
            model.ManagerID = user.Id;
            model.Date = DateTime.Now;
            model.PenaltyTypeList = penaltyTypeRepository.GetAll();
            model.EmployeeList = employeeRepository.GetEmployeeByID(model.EmployeeID);
            return View(model);

        }

        public IActionResult GetPenalty(int penID)
        {
            List<PenaltyType> penaltyType = penaltyTypeRepository.GetByID(penID);
            return Json(penaltyType);

        }

    }
}
