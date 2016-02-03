using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ARMCustomerWebSite;
using ARMCustomerWebSite.Controllers;
using ARMCustomerWebSite.Models;
using ARMCustomerWebSite.ViewModelFactories;
using Moq;

namespace ARMCustomerWebSite.Tests.Controllers
{
    [TestClass]
    public class ProductQueryControllerTest
    {
        [TestMethod]
        public void CreateWhenCalledReturnsCreateView()
        {
            // Arrange
            var mockVMFactory =new Mock<IProductQueryCreateViewModelFactory>();
            var model = new ProductQueryCreateViewModel();
            var countries = new Dictionary<int, string>();
            countries.Add(1, "UK");
            model.Countries = new SelectList(countries, "key", "value");
            var products = new Dictionary<int, string>();
            products.Add(1, "Some Product");
            model.Products = new SelectList(countries, "key", "value");

            mockVMFactory.Setup(ms => ms.Create()).Returns(model);
            ProductQueryController controller = new ProductQueryController(mockVMFactory.Object);
            
            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual("Create",result.ViewName);
        }
        //Many more tests need to be added .....
    }
}
