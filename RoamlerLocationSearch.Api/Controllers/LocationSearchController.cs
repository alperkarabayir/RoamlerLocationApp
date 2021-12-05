using AutoMapper;
using RoamlerLocationSearch.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoamlerLocationSearch.Core;
using RoamlerLocationSearch.Core.Services;
using GreenFluxAssignment.Api.Validators;

namespace BlueHarvest.Api.Controllers
{
    [Route("Location")]
    [ApiController]
    public class LocationSearchController : Controller
    {
        private readonly ILocationService _locationService;
       
        public LocationSearchController(ILocationService locationService)
        {
            this._locationService = locationService;
        }

        
        [HttpGet("")]
        public async Task<ActionResult<Result>> GetLocations([FromQuery] double latitude, [FromQuery] double longitude, [FromQuery] int maxDistance, [FromQuery] int maxResults)
        {
            Location locationIn = new Location(latitude, longitude, "");

            var validator = new LocationValidator();
            var validationResult = await validator.ValidateAsync(locationIn);

            if (!validationResult.IsValid)
                return BadRequest(string.Join(" / ", validationResult.Errors.Select( a => a.ErrorMessage.ToString())));

            try
            {
                var locations = await _locationService.GetLocations(locationIn, maxDistance, maxResults);
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
    }
}
