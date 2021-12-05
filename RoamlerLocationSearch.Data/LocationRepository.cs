using RoamlerLocationSearch.Core.Repositories;
using RoamlerLocationSearch.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoamlerLocationSearch.Data
{
    public class LocationRepository : ILocationRepository
    {
        public async Task<List<Location>> GetLocations()
        {
            return await GetLocationsReaderAsync();
        }

        /// <summary>
        /// Get Locations From CSV File asynchronously
        /// </summary>
        /// <returns> Locations </returns>
        private async Task<List<Location>> GetLocationsReaderAsync()
        {
            List<Location> Locations = new List<Location>();

            string fileLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "locations.csv");
            string[] allLines = await File.ReadAllLinesAsync(fileLocation);
            var locations = allLines.Skip(1).Select(line =>
            {
                var data = line.Split(new[] { "\",\"" }, StringSplitOptions.RemoveEmptyEntries);
                string Address = data.ElementAt(0) == null ? "" : data.ElementAt(0).TrimStart('\"');
                double Latitude = data.Length > 1 ? double.Parse(data.ElementAt(1)) : 0.0;
                double Longitude = data.Length > 2 ? double.Parse(data.ElementAt(2).TrimEnd('\"')) : 0.0;
                return new Location(Latitude, Longitude, Address);

            });
            Locations = locations.ToList();
            return Locations;
        }
    }
}
