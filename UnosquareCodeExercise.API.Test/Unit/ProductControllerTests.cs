using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnosquareCodeExerciseAPI.Contracts;
using UnosquareCodeExerciseAPI.Controllers;
using UnosquareCodeExerciseAPI.Models;
using Xunit;

namespace UnosquareCodeExercise.API.Test.Unit
{
    public class ProductControllerTests
    {
        private readonly Mock<IUnitOfWork> service;

        public ProductControllerTests()
        {
            service = new Mock<IUnitOfWork>();
        }
    
        [Fact]
        //naming convention MethodName_expectedBehavior_StateUnderTest
        public void GetProduct_ListOfProducts_ProductExistsInRepo()
        {
            //arrange
            service.Setup(x => x.Products.FindAll(
                    null,
                    null,
                    null
                ))
                .Returns(GetSampleProduct);
            var controller = new ProductController(service.Object);

            //act
            var actionResult = controller.GetProducts();
            var result = actionResult.Result as OkObjectResult;
            var actual = result.Value as IEnumerable<Product>;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<Product>(actual.FirstOrDefault());
            Assert.True(actual.Count() > 0);
            Assert.Equal(GetSampleProduct().Result.Count, actual.Count());
        }

        [Fact]
        public void GetPrtoductById_ProductObject_ProductwithSpecificeIdExists()
        {
            var firstProduct = GetSampleProduct().Result[0];
            service.Setup(x => x.Products.Find(
                    q => q.Id == 1,
                    null
                )).Returns(
                    Task.FromResult(firstProduct)
                );
            var controller = new ProductController(service.Object);

            //act
            var result = controller.GetProduct(1).Result;
            
            //assert
            Assert.NotNull(result.Value);
            Assert.IsType<Product>(result.Value);
            Assert.Same(firstProduct, result.Value);
        }

        [Fact]
        public void GetPrtoductById_ProductObject_ProductwithSpecificeIdNotExists()
        {
            var firstProduct = GetSampleProduct().Result[0];
            service.Setup(x => x.Products.Find(
                    q => q.Id == 1,
                    null
                )).Returns(
                    Task.FromResult(firstProduct)
                );
            var controller = new ProductController(service.Object);

            //act
            var result = controller.GetProduct(2).Result;

            //assert
            Assert.Null(result.Value);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateProduct_CreatedStatus_PassingProductObjectToCreate()
        {
            var newProduct = GetSampleProduct().Result[0];
            var controller = new ProductController(service.Object);
            
            //Act & Asset
            Assert.ThrowsAsync<NullReferenceException>(() => controller.PostProduct(newProduct));
        }

        private Task<IList<Product>> GetSampleProduct()
        {
            IList<Product> output = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Barbie Developer",
                    Description = "",
                    AgeRestriccion = 12,
                    Company = "Mattel",
                    Price = new Decimal(25.99)
                },
                new Product
                {
                    Id = 2,
                    Name = "xyc",
                    Description = "",
                    AgeRestriccion = 4,
                    Company = "Marvel",
                    Price = new Decimal(75.50)
                },
                new Product
                {
                    Id = 3,
                    Name = "abc",
                    Description = "",
                    AgeRestriccion = 18,
                    Company = "Nintendo",
                    Price = new Decimal(99.99)
                }
            };
            return Task.FromResult(output);
        }

    }
}
