using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkiAPI.Models;
using ParkiAPI.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace ParkiAPI.Controllers
{
    [Route("api/v{version:apiVersion}/nationalparks")]
    [ApiVersion("2.0")]
    //[Route("api/[controller]")] //changeable ~Burak
    [ApiController]
    //[ApiExplorerSettings(GroupName = "natParkiOpenAPISpecNationalParks")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class APIv2Controller : ControllerBase
    {
        private readonly INationalParkRepository nationalParkRepository;
        private readonly IMapper mapper;

        public APIv2Controller(
            INationalParkRepository nationalParkRepository,
            IMapper mapper
            )
        {
            this.nationalParkRepository = nationalParkRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get list of National Parks.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<NationalParkDto>))]
        public IActionResult GetNationalParks()
        {
            var obje = this.nationalParkRepository.GetNationalParks().FirstOrDefault();  
            return Ok(this.mapper.Map<NationalParkDto>(obje)); 
        }
    }
}
