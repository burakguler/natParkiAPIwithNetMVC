using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkiAPI.Models;
using ParkiAPI.Models.Dtos;
using ParkiAPI.Repository.IRepository;
using System.Collections.Generic;

namespace ParkiAPI.Controllers
{
    [Route("api/v{version:apiVersion}/trails")]
    //[Route("api/Trails")] //static ~Burak
    [ApiController]
    //[ApiExplorerSettings(GroupName = "natParkiOpenAPISpecTrails")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class TrailsController : ControllerBase
    {
        private readonly ITrailRepository trailRepository;
        private readonly IMapper mapper;

        public TrailsController(
            ITrailRepository trailRepository,
            IMapper mapper
            )
        {
            this.trailRepository = trailRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get list of Trails.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<TrailDto>))]
        public IActionResult GetTrails()
        {
            var objList = this.trailRepository.GetTrails();

            var objDto = new List<TrailDto>();

            foreach (var obje in objList) // by this loop we mapping 
            {                             // our tables to Dto tables ~Burak
                objDto.Add(this.mapper.Map<TrailDto>(obje));
            }
            return Ok(objDto);
        }
        /// <summary>
        /// Get individual Trail by Id.
        /// </summary>
        /// <param name="trailId">The Id of the Trail</param>
        /// <returns></returns>
        [HttpGet("{trailId:int}", Name = "GetTrail")]
        [ProducesResponseType(200, Type = typeof(TrailDto))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetTrail(int trailId) // gettingById singular item ~Burak
        {
            var obje = this.trailRepository.GetTrail(trailId);

            if (obje == null)
            {
                return NotFound();
            }
            var objDto = this.mapper.Map<TrailDto>(obje);
            return Ok(objDto);
        }
        /// <summary>
        /// Get individual Trail by National Park Id.
        /// </summary>
        /// <param name="trailId">The Id of the Trail</param>
        /// <returns></returns>
        [HttpGet("GetTrailInNatPark/{nationalParkId:int}", Name = "GetTrailInNatPark")]
        [ProducesResponseType(200, Type = typeof(TrailDto))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetTrailInNationalPark(int nationalParkId) // gettingById singular item ~Burak
        {
            var objeList = this.trailRepository.GetTrailsInNationalPark(nationalParkId);

            if (objeList == null)
            {
                return NotFound();
            }
            var objDto = new List<TrailDto>();
            foreach (var obje in objeList)
            {
                objDto.Add(this.mapper.Map<TrailDto>(obje));
            }
            
            return Ok(objDto);
        }
        /// <summary>
        /// Create Trail.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(TrailDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateTrail([FromBody] TrailCreateDto trailDto) // we do not want to create trails with national Park's properties
        {
            if (trailDto == null) // if dto table/form null return bad request ~Burak
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)    // if model state is not valid return bad request error ~Burak
            {
                return BadRequest(ModelState);
            }

            if (this.trailRepository.TrailExists(trailDto.Name))
            {                           // if this Trail does exists return error message down below and return status code 404 ~Burak        
                ModelState.AddModelError("", "Trail Exists!");
                return StatusCode(404, ModelState);
            }

            // if everythings fine continue to work
            var trailobje = this.mapper.Map<Trail>(trailDto);
            if (!this.trailRepository.CreateTrail(trailobje))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {trailobje.Name}");

                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetTrail", new { trailId = trailobje.Id }, trailobje);
        }
        /// <summary>
        /// Update Trail by Id.
        /// </summary>
        /// <param name="trailId">The Id of the Trail</param>
        /// <returns></returns>
        [HttpPatch("{trailId:int}", Name = "UpdateTrail")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateTrail(int trailId, [FromBody] TrailUpdateDto trailDto)
        {
            if (trailDto == null || trailId != trailDto.Id) // if dto table/form null return bad request ~Burak
            {
                return BadRequest(ModelState);
            }

            // if everythings fine continue to work ~Burak
            var trailobje = this.mapper.Map<Trail>(trailDto);
            if (!this.trailRepository.UpdateTrail(trailobje))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {trailobje.Name}");

                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        /// <summary>
        /// Delete Trail by Id.
        /// </summary>
        /// <param name="trailId">The Id of the Trail</param>
        /// <returns></returns>
        [HttpDelete("{trailId:int}", Name = "DeleteTrail")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteTrail(int trailId)
        {
            if (!this.trailRepository.TrailExists(trailId))
            {
                // if this national does exists return not found error message down below ~Burak 
                return NotFound();
            }

            // if everythings fine continue to work ~Burak
            var trailobje = this.trailRepository.GetTrail(trailId);
            if (!this.trailRepository.DeleteTrail(trailobje))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {trailobje.Name}");

                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

    }
}
