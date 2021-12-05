using RoamlerLocationSearch.Core.Repositories;
using RoamlerLocationSearch.Core.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoamlerLocationSearch.Services.Domain;
using RoamlerLocationSearch.Core.Services;

namespace RoamlerLocationSearch.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public LocationService(ILocationRepository locationRepository, IMapper mapper)
        {
            this._locationRepository = locationRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// Get Ordered Locations 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="maxDistance"></param>
        /// <param name="maxResults"></param>
        /// <returns></returns>
        public async Task<Result> GetLocations(Location location, int maxDistance, int maxResults)
        {
            List<Location> Locations = new List<Location>();
            try
            {
                // Getting All Locations
                Locations = await _locationRepository.GetLocations();

                // Map Locations to Domain
                var locationDomain = _mapper.Map<List<Location>, List<LocationDomain>>(Locations);

                // Map Input Location to Domain
                var locationIn = _mapper.Map<Location, LocationDomain>(location);

                // Calculate Distance with Given Location - Control Max Distance - Order By Distance
                locationDomain = locationDomain.Select(c =>
                {
                    c.CalculateDistance(locationIn);
                    if (maxDistance >= c.Distance)
                    {
                        return c;
                    }
                    return null;
                })
                    .Where(c => c != null)
                    .OrderBy(c => c.Distance)
                    .Take(maxResults).ToList();

                Locations = _mapper.Map<List<LocationDomain>, List<Location>>(locationDomain);


                Result result = new Result();
                result.Latitude = location.Latitude;
                result.Longitude = location.Longitude;
                result.MaxDistance = maxDistance;
                result.MaxResults = maxResults;
                result.Locations = Locations;
                result.TotalResults = Locations.Count;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
