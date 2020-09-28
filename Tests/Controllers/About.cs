using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChrisCafeTests.Controllers
{
    [TestClass]
    public class About
    {
        [TestMethod]
        public void About_Index_ReturnsViewResult()
        {
            // Arrange
            var Controller = new ChrisCafe.Controllers.AboutController();

            // Act
            var Result = Controller.Index();

            // Assert
            Assert.IsInstanceOfType(Result, typeof(ViewResult));
        }

        [TestMethod]
        public void About_Index_SetsCurrentPage()
        {
            var Controller = new ChrisCafe.Controllers.AboutController();
            var Result = Controller.Index() as ViewResult;
            Assert.AreEqual("About", Result.ViewData["CurrentPage"]);
        }

        [TestMethod]
        public void About_Contact_ReturnsViewResult()
        {
            var Controller = new ChrisCafe.Controllers.AboutController();
            var Result = Controller.Contact();
            Assert.IsInstanceOfType(Result, typeof(ViewResult));
        }

        [TestMethod]
        public void About_Contact_SetsCurrentPage()
        {
            var Controller = new ChrisCafe.Controllers.AboutController();
            var Result = Controller.Contact() as ViewResult;
            Assert.AreEqual("ContactLocate", Result.ViewData["CurrentPage"]);
        }
    }
}
