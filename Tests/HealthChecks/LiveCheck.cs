using ChrisCafe.Providers;
using ChrisCafe.Data.Caches;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;

namespace ChrisCafeTests.HealthChecks
{
    [TestClass]
    public class Livecheck
    {
        [TestMethod]
        public void IsAlive()
        {
            // Arrange
            var context = new HealthCheckContext();

            // Instantiate using full namespace to avoid conflict with test class name.
            var live = new ChrisCafe.Models.HealthChecks.LiveCheck();

            // Act
            // Should normally be awaited, but MSTest isn't running async test methods, for whatever reason.
            var result = live.CheckHealthAsync(context);

            // Assert
            // Assert that the task ran to completion with a health result.
            bool taskStatus = result.Status == System.Threading.Tasks.TaskStatus.RanToCompletion;
            Assert.IsTrue(taskStatus);
            Assert.IsTrue(result.Result.Status == HealthStatus.Healthy);
        }
    }
}
