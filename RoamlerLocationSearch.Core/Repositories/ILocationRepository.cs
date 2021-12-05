using RoamlerLocationSearch.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoamlerLocationSearch.Core.Repositories
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetLocations();
    }
}