using ChrisCafe.Providers;
using ChrisCafe.Data.Caches;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;

namespace ChrisCafeTests.HealthChecks
{
    [TestClass]
    public class IntegrityCheck : IDisposable
    {
        [TestMethod]
        public void ValidCache()
        {
            // Arrange
            var context = new HealthCheckContext();

            // Instantiate using full namespace to avoid conflict with test class name.
            var integrity = new ChrisCafe.Models.HealthChecks.IntegrityCheck();

            // Act
            // Should normally be awaited, but MSTest isn't running async test methods, for whatever reason.
            var result = integrity.CheckHealthAsync(context);

            // Assert
            // Assert that the task ran to completion with a health result.
            bool taskStatus = result.Status == System.Threading.Tasks.TaskStatus.RanToCompletion;
            Assert.IsTrue(taskStatus); 
            Assert.IsTrue(result.Result.Status == HealthStatus.Healthy);
        }

        [TestMethod]
        public void InvalidCache()
        {
            // Arrange
            var context = new HealthCheckContext();
            var integrity = new ChrisCafe.Models.HealthChecks.IntegrityCheck();

            // Act
            // Break part the cache so the health check fails
            Cache.Menu.CachedFullMenu.BreakfastMenu.Items.Clear();

            var result = integrity.CheckHealthAsync(context);

            // Assert
            // Assert that the task ran to completion with a health result.
            bool taskStatus = result.Status == System.Threading.Tasks.TaskStatus.RanToCompletion;
            Assert.IsTrue(taskStatus);
            Assert.IsTrue(result.Result.Status == HealthStatus.Unhealthy);
        }

        /// <summary>
        /// Reset the menu cache to ensure it's in a valid state for the next test.
        /// Dispose is called after each test is run.
        /// </summary>
        public void Dispose()
        {
            ChrisCafe.Data.DataInitializer.InitializeAll();
        }
    }
}
