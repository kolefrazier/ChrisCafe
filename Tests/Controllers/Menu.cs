using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChrisCafeTests.Controllers
{
    [TestClass]
    public class Menu
    {
        [TestMethod]
        public void ReturnsIndexViewResult()
        {
            // Arrange
            var Controller = new ChrisCafe.Controllers.MenuController();

            // Act
            var Result = Controller.Index(String.Empty);

            // Assert
            Assert.IsInstanceOfType(Result, typeof(ViewResult));
        }

        [TestMethod]
        public void SetsCurrentPageIndex()
        {
            var Controller = new ChrisCafe.Controllers.MenuController();
            var Result = Controller.Index(String.Empty) as ViewResult;
            Assert.AreEqual("Menu", Result.ViewData["CurrentPage"]);
        }

        [TestMethod]
        public void RedirectsDinnerToHomeIndex()
        {
            var Controller = new ChrisCafe.Controllers.MenuController();
            var Result = Controller.Dinner() as RedirectToActionResult;

            Assert.AreEqual(Result.ControllerName, "Home");
            Assert.AreEqual(Result.ActionName, "Index");
        }

    }
}
