using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkiWEB.Models;
using ParkiWEB.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ParkiWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INationalParkRepository nationalParkRepository;
        private readonly ITrailRepository trailRepository;

        public HomeController(ILogger<HomeController> logger, INationalParkRepository nationalParkRepository, ITrailRepository trailRepository)
        {
            _logger = logger;
            this.nationalParkRepository = nationalParkRepository;
            this.trailRepository = trailRepository;
        }

        public async Task<IActionResult> IndexAsync()
        {
            IndexViewModel listOfParkAndTrails = new IndexViewModel()
            {
                NationalParkList = await this.nationalParkRepository.GetAllAsync(StaticDetails.NationalParkAPIPath),
                TrailList = await this.trailRepository.GetAllAsync(StaticDetails.TrailAPIPath),
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
    }
}
