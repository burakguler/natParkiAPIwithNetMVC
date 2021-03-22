using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkiWEB.Models;
using ParkiWEB.Repository.IRepository;
using System.IO;
using System.Threading.Tasks;

namespace ParkiWEB.Controllers
{
    [Authorize]
    public class NationalParksController : Controller
    {
        private readonly INationalParkRepository nationalParkRepository;
        private readonly object files;

        public NationalParksController(INationalParkRepository nationalParkRepository)
        {
            this.nationalParkRepository = nationalParkRepository;
        }
        public IActionResult Index()
        {
            return View(new NationalPark() {});
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpsertAsync(int? id)
        {
            NationalPark obje = new NationalPark();
            if (id==null)
            {
                return (View(obje));
            }
            // after pressed to update or edit button cursor will come here
            obje = await this.nationalParkRepository.GetAsync(StaticDetails.NationalParkAPIPath, id.GetValueOrDefault(), HttpContext.Session.GetString("JWToken"));
            if (obje == null)
            {
                return NotFound();
            }
            return View(obje);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(NationalPark obje)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count>0)
                {
                    byte[] url = null;
                    using (var fileStream = files[0].OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            fileStream.CopyTo(memoryStream);
                            url = memoryStream.ToArray();
                        }

                    }
                    obje.Image = url;
                }
                else
                {
                    var objeFromDb = await this.nationalParkRepository.GetAsync(StaticDetails.NationalParkAPIPath, obje.Id, HttpContext.Session.GetString("JWToken"));
                    obje.Image = objeFromDb.Image;
                }
                if (obje.Id == 0)
                {
                    await this.nationalParkRepository.CreateAsync(StaticDetails.NationalParkAPIPath, obje, HttpContext.Session.GetString("JWToken"));
                }
                else
                {
                    await this.nationalParkRepository.UpdateAsync(StaticDetails.NationalParkAPIPath + obje.Id, obje, HttpContext.Session.GetString("JWToken"));
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(obje);
            }
        }

        public async Task<IActionResult> GetAllNationalPark()
        {
            return Json(new { data = await this.nationalParkRepository.GetAllAsync(StaticDetails.NationalParkAPIPath, HttpContext.Session.GetString("JWToken")) });
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await this.nationalParkRepository.DeleteAsync(StaticDetails.NationalParkAPIPath, id, HttpContext.Session.GetString("JWToken"));
            if (status)
            {
                return Json(new {success=true, message= "Deleted Successfully" });
            }

            return Json(new { success = false, message = "Delete proccess not successful" });
        }
    }
}
