using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirstResponsiveWebAppHillaker.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FirstResponsiveWebAppHillaker.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Index_Get_ReturnsView()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}