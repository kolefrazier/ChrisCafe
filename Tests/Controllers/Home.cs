using System;
using System.Collections.Generic;
using System.Text;
using ChrisCafe.Data.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChrisCafeTests.Controllers
{
    [TestClass]
    public class Home
    {
        [TestMethod]
        public void Home_Index_ReturnsViewResult()
        {
            // Arrange
            var Controller = new ChrisCafe.Controllers.HomeController(new DateTimeProvider());

            // Act
            var Result = Controller.Index();

            // Assert
            Assert.IsInstanceOfType(Result, typeof(ViewResult));
        }

        [TestMethod]
        public void Home_Index_SetsCurrentPage()
        {
            var Controller = new ChrisCafe.Controllers.HomeController(new DateTimeProvider());
            var Result = Controller.Index() as ViewResult;
            Assert.AreEqual("Home", Result.ViewData["CurrentPage"]);
        }
    }
}
