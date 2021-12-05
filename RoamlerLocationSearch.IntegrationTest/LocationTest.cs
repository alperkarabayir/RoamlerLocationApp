using RoamlerLocationSearch.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RoamlerLocationSearch.IntegrationTest
{
    public class LocationTest
    {
        private readonly HttpClient _client;

        public LocationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            //Arrange
            _client = appFactory.CreateClient();
        }

        [Fact]
        public async Task GetList_Location()
        {
            //Act 
            //Testing with Latitude = 10 Longitude = 10 maxDistance = 10 maxResults = 10
            var response = await _client.GetAsync("/Location?latitude=10&longitude=10&maxDistance=10&maxResults=10");

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task GetList_Location_LatitudeOutOfRange()
        {
            //Act 
            //Testing with Latitude = 100 Longitude = 10 maxDistance = 10 maxResults = 10
            var response = await _client.GetAsync("/Location?latitude=100&longitude=10&maxDistance=10&maxResults=10");

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetList_Location_LongitudeOutOfRange()
        {
            //Act 
            //Testing with Latitude = 10 Longitude = 190 maxDistance = 10 maxResults = 10
            var response = await _client.GetAsync("/Location?latitude=10&longitude=190&maxDistance=10&maxResults=10");

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
