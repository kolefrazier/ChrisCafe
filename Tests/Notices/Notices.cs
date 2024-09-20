using System;
using System.Collections.Generic;
using System.Text;
using ChrisCafe.Data;
using ChrisCafe.Data.Caches;
using ChrisCafe.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ChrisCafeTests.Notices
{
    [TestClass]
    public class Notices
    {
        // TODO: Rework where these dates come from. Non-static days shouldn't need to be updated when the live
        //      notices file updates.
        [TestMethod]
        [DataRow(2020, 7, 4, "flagUSA", "fireworks", "alert-primary", 1)] // 4th of July
        [DataRow(2020, 7, 24, "flagUSA", "fireworks", "alert-primary", 1)] // Pioneer Day
        //[DataRow(2020, 11, 24, "turkey", "cornucopia", "alert-primary", 2)] // Thanksgiving 
        //[DataRow(2020, 11, 25, "", "", "alert-primary", 1)] // Black Friday
        [DataRow(2020, 12, 24, "christmas-tree", "candy-cane", "alert-success", 2)] // Christmas Eve
        [DataRow(2020, 12, 25, "christmas-tree", "candy-cane", "alert-success", 1)] // Christmas
        [DataRow(2020, 12, 31, "fireworks", "confetti", "alert-primary", 1)] // New Year's Eve
        [DataRow(2020, 1, 1, "fireworks", "confetti", "alert-primary", 1)] // New Year's Day
        public void CorrectNoticeReturned(int year, int month, int day, string iconLeft, string iconRight, string styleClass, int messagesLength)
        {
            // References for Moq use with dependency injection:
            // * https://github.com/Moq/moq4/wiki/Quickstart
            // * https://codopia.wordpress.com/2017/04/24/how-to-mock-up-datetime-now-in-unit-tests-using-ambient-context-pattern/

            // Arrange - Setup DateTimeProvider mock
            var DateTimeProvider = new Mock<IDateTimeProvider>();
            var FakeDate = new DateTime(year, month, day);
            DateTimeProvider.Setup(s => s.Today).Returns(FakeDate);

            // Act - Get Notice
            //  It feels weird to not pass the normally dependency-injected DateTimeProvider
            //  into the constructor. But, it makes sense for its normal use in a controller.
            var result = Cache.Notices.GetNotice(DateTimeProvider.Object);

            // Assert
            Assert.AreEqual(result.IconLeft, iconLeft);
            Assert.AreEqual(result.IconRight, iconRight);
            Assert.AreEqual(result.StyleClass, styleClass);
            Assert.AreEqual(result.Messages.Length, messagesLength);
        }

        [TestMethod]
        public void NoticeDoesNotExist()
        {
            // Arrange - Setup DateTimeProvider mock
            var DateTimeProvider = new Mock<IDateTimeProvider>();
            var FakeDate = new DateTime(2020, 7, 5);
            DateTimeProvider.Setup(s => s.Today).Returns(FakeDate);

            // Act - Get Notice
            //  It feels weird to not pass the normally dependency-injected DateTimeProvider
            //  into the constructor. But, it makes sense for its normal use in a controller.
            var result = Cache.Notices.GetNotice(DateTimeProvider.Object);

            // Assert
            Assert.IsNull(result);
        }
    }
}
