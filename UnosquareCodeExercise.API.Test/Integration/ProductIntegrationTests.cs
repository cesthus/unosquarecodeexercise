using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnosquareCodeExerciseAPI.Models;
using Xunit;

namespace UnosquareCodeExercise.API.Test.Integration
{
    public class ProductIntegrationTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public ProductIntegrationTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetProductItemsAsync()
        {
            // Arrange
            var request = "/api/product";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestGetProductItemAsync()
        {
            // Arrange
            var request = "/api/product/1";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPostProductItemAsync()
        {
            //Arrange
            var request = new
            {
                Url = "/api/product",
                Body = new Product
                {
                    Name = "Integration test",
                    Price = 2,
                    AgeRestriccion = 10,
                    Company = "marvel",
                    Description = "desc"
                }
            };

            //Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            //Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPutProductItemAsync()
        {
            //arange
            var request = new
            {
                Url = "api/product/1",
                Body = new Product
                {
                    Name = "Roma test",
                    Price = 45,
                    AgeRestriccion = 13,
                    Company = "Maaa",
                    Id = 1
                }
            };

            //act
            var response = await Client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            //assert
            response.EnsureSuccessStatusCode();
        }



    }
}
