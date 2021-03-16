using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkiWEB.Models;
using ParkiWEB.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ParkiWEB.Controllers
{
    
    public class LoginRegisterController : Controller
    {
        private readonly ILogger<LoginRegisterController> logger;
        private readonly INationalParkRepository nationalParkRepository;
        private readonly IAccountRepository accountRepository;
        private readonly ITrailRepository trailRepository;

        public LoginRegisterController(ILogger<LoginRegisterController> logger,
                                       INationalParkRepository nationalParkRepository,
                                       ITrailRepository trailRepository,
                                       IAccountRepository accountRepository)
        {
            this.logger = logger;
            this.nationalParkRepository = nationalParkRepository;
            this.trailRepository = trailRepository;
            this.accountRepository = accountRepository;
        }
        [HttpGet]
        public IActionResult Login()
        {
            User obje = new User();
            return View(obje);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

      

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString("JWToken", "");
            return RedirectToAction("Index");
        }

    }
}
