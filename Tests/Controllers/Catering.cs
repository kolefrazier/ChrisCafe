using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChrisCafeTests.Controllers
{
    [TestClass]
    public class Catering
    {
        [TestMethod]
        public void Catering_Index_ReturnsViewResult()
        {
            // Arrange
            var Controller = new ChrisCafe.Controllers.AboutController();

            // Act
            var Result = Controller.Index();

            // Assert
            Assert.IsInstanceOfType(Result, typeof(ViewResult));
        }

        [TestMethod]
        public void Catering_Index_SetsCurrentPage()
        {
            var Controller = new ChrisCafe.Controllers.CateringController();
            var Result = Controller.Index() as ViewResult;
            Assert.AreEqual("Catering", Result.ViewData["CurrentPage"]);
        }
    }
}
