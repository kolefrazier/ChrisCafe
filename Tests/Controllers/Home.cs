using ChrisCafe.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChrisCafeTests.Controllers
{
    [TestClass]
    public class Home
    {
        [TestMethod]
        public void ReturnsIndexViewResult()
        {
            // Arrange
            var Controller = new ChrisCafe.Controllers.HomeController(new DateTimeProvider());

            // Act
            var Result = Controller.Index();

            // Assert
            Assert.IsInstanceOfType(Result, typeof(ViewResult));
        }

        [TestMethod]
        public void SetsCurrentPageIndex()
        {
            var Controller = new ChrisCafe.Controllers.HomeController(new DateTimeProvider());
            var Result = Controller.Index() as ViewResult;
            Assert.AreEqual("Home", Result.ViewData["CurrentPage"]);
        }
    }
}
