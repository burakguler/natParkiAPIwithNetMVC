using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkiWEB.Models;
using ParkiWEB.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ParkiWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INationalParkRepository nationalParkRepository;
        private readonly IAccountRepository accountRepository;
        private readonly ITrailRepository trailRepository;

        public HomeController(ILogger<HomeController> logger, INationalParkRepository nationalParkRepository, ITrailRepository trailRepository, IAccountRepository accountRepository)
        {
            _logger = logger;
            this.nationalParkRepository = nationalParkRepository;
            this.trailRepository = trailRepository;
            this.accountRepository = accountRepository; 
        }

        public async Task<IActionResult> IndexAsync()
        {
            IndexViewModel listOfParkAndTrails = new IndexViewModel()
            {
                NationalParkList = await this.nationalParkRepository.GetAllAsync(StaticDetails.NationalParkAPIPath, HttpContext.Session.GetString("JWToken")),
                TrailList = await this.trailRepository.GetAllAsync(StaticDetails.TrailAPIPath, HttpContext.Session.GetString("JWToken")),
            };
            return View(listOfParkAndTrails);
        }

        public IActionResult Theme()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            User obje = new User();
            return View(obje);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User obje)
        {
            User objeUser = await this.accountRepository.LoginAsync(StaticDetails.AccountAPIPath + "authenticate/", obje);
            if (objeUser.Token == null)
            {
                return View();
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, objeUser.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, objeUser.Role));
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            HttpContext.Session.SetString("JWToken", objeUser.Token);
            return RedirectToAction("Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User obje)
        {
            bool result = await this.accountRepository.RegisterAsync(StaticDetails.AccountAPIPath + "register/", obje);
            if (result == false)
            {
                return View();
            }
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString("JWToken", "");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
