using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkiAPI.Models;
using ParkiAPI.Repository.IRepository;
using System.Collections.Generic;

namespace ParkiAPI.Controllers
{
    [Route("api/v{version:apiVersion}/nationalparks")]
    //[Route("api/[controller]")] //changeable ~Burak
    [ApiController]
    //[ApiExplorerSettings(GroupName = "natParkiOpenAPISpecNationalParks")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class NationalParksController : ControllerBase
    {
        private readonly INationalParkRepository nationalParkRepository;
        private readonly IMapper mapper;

        public NationalParksController(
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
            var objList = this.nationalParkRepository.GetNationalParks();

            var objDto = new List<NationalParkDto>();

            foreach (var obje in objList) // by this loop we mapping 
            {                             // our tables to Dto tables ~Burak
                objDto.Add(this.mapper.Map<NationalParkDto>(obje));
            }
            return Ok(objDto); 
        }
        /// <summary>
        /// Get individual National Park by Id.
        /// </summary>
        /// <param name="nationalParkId">The Id of the National Park</param>
        /// <returns></returns>
        [HttpGet("{nationalParkId:int}", Name ="GetNationalPark")]
        [ProducesResponseType(200, Type = typeof(List<NationalParkDto>))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetNationalPark(int nationalParkId) // gettingById singular item ~Burak
        {
            var obje = this.nationalParkRepository.GetNationalPark(nationalParkId);

            if (obje == null)
            {
                return NotFound();
            }
            var objDto = this.mapper.Map<NationalParkDto>(obje);
            return Ok(objDto);
        }
        /// <summary>
        /// Create National Park.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(List<NationalParkDto>))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateNationalPark([FromBody] NationalParkDto nationalParkDto)
        {
            if (nationalParkDto == null) // if dto table/form null return bad request ~Burak
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)    // if model state is not valid return bad request error ~Burak
            {
                return BadRequest(ModelState);
            }

            if (this.nationalParkRepository.NationalParkExists(nationalParkDto.Name))
            {                           // if this national does exists return error message down below and return status code 404 ~Burak        
                ModelState.AddModelError("", "National Park Exists!"); 
                return StatusCode(404, ModelState);
            }
           
            // if everythings fine continue to work
            var nationalParkobje = this.mapper.Map<NationalPark>(nationalParkDto);
            if (!this.nationalParkRepository.CreateNationalPark(nationalParkobje))
            {
               ModelState.AddModelError("", $"Something went wrong when saving the record {nationalParkobje.Name}");

               return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetNationalPark", new {version=HttpContext.GetRequestedApiVersion().ToString(), 
                                                          nationalParkId=nationalParkobje.Id},nationalParkobje);
        }
        /// <summary>
        /// Update National Park by Id.
        /// </summary>
        /// <param name="nationalParkId">The Id of the National Park</param>
        /// <returns></returns>
        [HttpPatch("{nationalParkId:int}", Name = "UpdateNationalPark")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateNationalPark(int nationalParkId,[FromBody] NationalParkDto nationalParkDto)
        {
            if (nationalParkDto == null || nationalParkId!=nationalParkDto.Id) // if dto table/form null return bad request ~Burak
            {
                return BadRequest(ModelState);
            }

            // if everythings fine continue to work ~Burak
            var nationalParkobje = this.mapper.Map<NationalPark>(nationalParkDto);
            if (!this.nationalParkRepository.UpdateNationalPark(nationalParkobje))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {nationalParkobje.Name}");

                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        /// <summary>
        /// Delete National Park by Id.
        /// </summary>
        /// <param name="nationalParkId">The Id of the National Park</param>
        /// <returns></returns>
        [HttpDelete("{nationalParkId:int}", Name = "DeleteNationalPark")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteNationalPark(int nationalParkId)
        {
            if (!this.nationalParkRepository.NationalParkExists(nationalParkId))
            {
                // if this national does exists return not found error message down below ~Burak 
                return NotFound();
            }

            // if everythings fine continue to work ~Burak
            var nationalParkobje = this.nationalParkRepository.GetNationalPark(nationalParkId);
            if (!this.nationalParkRepository.DeleteNationalPark(nationalParkobje))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {nationalParkobje.Name}");

                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

    }
}
