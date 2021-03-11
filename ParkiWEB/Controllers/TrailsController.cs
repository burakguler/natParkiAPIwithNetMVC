using Microsoft.AspNetCore.Mvc;
using ParkiWEB.Models;
using ParkiWEB.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ParkiWEB.Controllers
{
    public class TrailsController : Controller
    {
        private readonly INationalParkRepository nationalParkRepository;
        private readonly ITrailRepository trailRepository;

        public TrailsController(ITrailRepository trailRepository, INationalParkRepository nationalParkRepository)
        {
            this.trailRepository = trailRepository;
            this.nationalParkRepository = nationalParkRepository;

        }
        public IActionResult Index()
        {
            return View(new Trail() { });
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            IEnumerable<NationalPark> nationalParkList = await this.nationalParkRepository.GetAllAsync(StaticDetails.NationalParkAPIPath);
            TrailsViewModel objeViewModel = new TrailsViewModel()
            {
                NationalParkList = nationalParkList.Select(İ => new SelectListItem
                {
                    Text = İ.Name,
                    Value = İ.Id.ToString()
                }),
                Trail = new Trail()
            };

            if (id == null)
            {
                return (View(objeViewModel));
            }
            // after pressed to update or edit button cursor will come here
            objeViewModel.Trail = await this.trailRepository.GetAsync(StaticDetails.TrailAPIPath, id.GetValueOrDefault());
            if (objeViewModel == null)
            {
                return NotFound();
            }
            return View(objeViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(TrailsViewModel obje)
        {
            if (ModelState.IsValid)
            {
                if (obje.Trail.Id == 0)
                {
                    await this.trailRepository.CreateAsync(StaticDetails.TrailAPIPath, obje.Trail);
                }
                else
                {
                    await this.trailRepository.UpdateAsync(StaticDetails.TrailAPIPath + obje.Trail.Id, obje.Trail);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                IEnumerable<NationalPark> nationalParkList = await this.nationalParkRepository.GetAllAsync(StaticDetails.NationalParkAPIPath);
                TrailsViewModel objeViewModel = new TrailsViewModel()
                {
                    NationalParkList = nationalParkList.Select(İ => new SelectListItem
                    {
                        Text = İ.Name,
                        Value = İ.Id.ToString()
                    }),
                    Trail = obje.Trail
                };

                return View(objeViewModel);
            }
        }

        public async Task<IActionResult> GetAllTrail()
        {
            return Json(new { data = await this.trailRepository.GetAllAsync(StaticDetails.TrailAPIPath) });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await this.trailRepository.DeleteAsync(StaticDetails.TrailAPIPath, id);
            if (status)
            {
                return Json(new { success = true, message = "Deleted Successfully" });
            }

            return Json(new { success = false, message = "Delete proccess not successful" });
        }
    }
}
