using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoamlerLocationSearch.Services.Domain;

namespace RoamlerLocationSearch.UnitTest
{
    [TestClass]
    public class LocationTest
    {
        [TestMethod]
        public void Group_CreateTest()
        {
            // Act
            // Create a location like in csv file
            string address = "Example";
            double latitude = 10;
            double longitude = 100;
            LocationDomain location = new LocationDomain(address, latitude, longitude);

            // Give a location for distance calculation
            double latitude2 = 11;
            double longitude2 = 100;
            LocationDomain location2 = new LocationDomain("", latitude2, longitude2);

            location.CalculateDistance(location2);

            // Between latitude = 10 and latitude = 11 calculated as 111189.57696002942
            double distance = 111189.57696002942;

            // Assert
            Assert.AreEqual(location.Distance, distance);
        }
    }
}
