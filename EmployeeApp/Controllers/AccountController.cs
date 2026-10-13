using EmployeeApp.Models;
using EmployeeApp.Repository;
using EmployeeApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IDepartmentRepository departmentRepository;
        private readonly ILogger<AccountController> logger;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager , IDepartmentRepository departmentRepository ,ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.departmentRepository = departmentRepository;
            this.logger = logger;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            model.Dept_List = departmentRepository.GettAll();
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                //Mapping
                ApplicationUser user = new ApplicationUser();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.PasswordHash = model.Password;
                user.DepartmentID = model.DepartmentID;

                //Check 
                IdentityResult result = await userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    if (model.DepartmentID == 2)
                    {
                        await userManager.AddToRoleAsync(user, "HR");
                    }
                    else if (model.DepartmentID == 3)
                    {
                        await userManager.AddToRoleAsync(user, "Sales");
                    }
                    else if (model.DepartmentID == 1)
                    {
                        await userManager.AddToRoleAsync(user, "IT");
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(user, "User");
                    }
                    await signInManager.SignInAsync(user, isPersistent: true);
                    return RedirectToAction("Index", "Employee");

                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("" , item.Description);
                    
                }
            }
          

            model.Dept_List = departmentRepository.GettAll();
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]

        public IActionResult Login()
        {
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.UserName,
                    model.Password,
                    isPersistent: true,
                    lockoutOnFailure: false
                );

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");

                ModelState.AddModelError(
                    "",
                    "UserName Or Password Wrong !"
                );

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred during POST /Account/Login"
                );

                return StatusCode(
                    500,
                    "An internal error occurred. Check the application logs."
                );
            }
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[AllowAnonymous]

        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    if (ModelState.IsValid == true)
        //    {
        //        //Check Found 
        //        ApplicationUser user = await userManager.FindByNameAsync(model.UserName);

        //        if (user != null)
        //        {
        //            //Check Password
        //            bool checkPassword = await userManager.CheckPasswordAsync(user, model.Password);
        //            if (checkPassword == true)
        //            {
        //                //Save Cookies
        //                await signInManager.SignInAsync(user, isPersistent: true);

        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        ModelState.AddModelError("", "UserName Or Password Wrong !");
        //    }
        //    return View(model);

        //}
        [AllowAnonymous]
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
