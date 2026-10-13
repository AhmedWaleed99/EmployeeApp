using EmployeeApp.Models;
using EmployeeApp.Repository;
using EmployeeApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    [Authorize(Roles = "Admin,HR")]
    public class PenaltyController : Controller
    {
        private readonly IPenaltyTypeRepository penaltyTypeRepository;

        public PenaltyController(IPenaltyTypeRepository penaltyTypeRepository)
        {
            this.penaltyTypeRepository = penaltyTypeRepository;
        }
        public IActionResult Index()
        {
            return View(penaltyTypeRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(PenaltyTypeViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                PenaltyType penalty = new PenaltyType();
                penalty.Name = model.Name; 
                penalty.DefaultAmount = model.DefaultAmount; 
                penalty.IsActive = model.IsActive;
                penaltyTypeRepository.Add(penalty);
                penaltyTypeRepository.Save();
                return RedirectToAction("Index");
                
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            PenaltyType penalty = penaltyTypeRepository.GetById(id);
            if (penalty != null)
            {
                PenaltyTypeViewModel model = new PenaltyTypeViewModel();
                model.ID = penalty.ID;
                model.Name = penalty.Name; 
                model.DefaultAmount = penalty.DefaultAmount; 
                model.IsActive = penalty.IsActive; 
                return View(model);
            }
            return NotFound();
        }
        public IActionResult Edit(PenaltyTypeViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                PenaltyType penalty = penaltyTypeRepository.GetById(model.ID);
                penalty.Name = model.Name;
                penalty.DefaultAmount = model.DefaultAmount;
                penalty.IsActive = model.IsActive;
                penaltyTypeRepository.Update(penalty);
                penaltyTypeRepository.Save();
                return RedirectToAction("Index");

            }
            return View(model);
        }
    }
}
