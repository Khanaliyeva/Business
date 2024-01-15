using Business.Business.Services.Interfaces;
using Business.Business.ViewModels.AccountVM;
using Business.Core.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Business.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(IAccountService service,SignInManager<AppUser> signInManager)
        {
            _service = service;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVm);
            }

            AppUser user = await _service.Login(loginVm);
            var result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or Password is wrong");
                return View(loginVm);
            }

            return RedirectToAction("Index", "Home");
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult>  Register(RegisterVm registerVm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result =await _service.Register(registerVm);
            await _signInManager.SignInAsync(result, false);
            return RedirectToAction(nameof(Index), "Home");
        }
        
        
        
        public async Task<IActionResult> LogOut()
        {
            return View(); await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
        
        

    }
}
