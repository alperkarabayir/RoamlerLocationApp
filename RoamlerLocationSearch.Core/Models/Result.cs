using System.Collections.Generic;

namespace RoamlerLocationSearch.Core.Models
{
    public class Result
    {
        public ICollection<Location> Locations { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int RecordCount { get; set; }
        public int MaxDistance { get; set; }
        public int MaxResults { get; set; }
        public int TotalResults { get; set; }
    }
}
