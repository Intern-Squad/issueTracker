using IssueTracker.Models;
using IssueTracker.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace IssueTracker.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
       

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
           
        }

        // GET:/Account/Register
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        
        //POST:/Account/Register
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = registerModel.email,
                    Email = registerModel.email,
                    name = registerModel.name
                };

                var result = await userManager.CreateAsync(user, registerModel.password);

                if (result.Succeeded)
                {

                    await signInManager.SignInAsync(user, isPersistent: false);

                   // await userManager.AddToRoleAsync(user, SystemRoles.Submitter.ToString());

                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View();
        }

       
        //Get:/Account/Login
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        //POST:/Account/Login
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
               var result = await signInManager.PasswordSignInAsync(
                   loginModel.email, loginModel.password, loginModel.rememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

              
                ModelState.AddModelError("", "Invalid Email or Password");
             

            }

         
            return View();
        }

        //POST:/Account/Logot
        //Since only logged in user can log out it is not allowed for anonymous user
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }


        //This action is to verify whether the email id of the user is already in the database or is already registered
        [HttpGet]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user =  await  userManager.FindByEmailAsync(email);

            if (user == null) return Json(true);

            return Json($"{email} is already in use");
        }

    }
}
