using RoamlerLocationSearch.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoamlerLocationSearch.Core.Services
{
    public interface ILocationService
    {
        Task<Result> GetLocations(Location location, int maxDistance, int maxResults);
    }
}
