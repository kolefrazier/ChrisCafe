using System;
using System.Collections.Generic;
using System.Text;
using ChrisCafe.Data;
using ChrisCafe.Data.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ChrisCafeTests.Notices
{
    [TestClass]
    public class Notices
    {
        [TestMethod]
        public void Notices_NoticeExists()
        {
            // References for Moq use with dependency injection:
            // * https://github.com/Moq/moq4/wiki/Quickstart
            // * https://codopia.wordpress.com/2017/04/24/how-to-mock-up-datetime-now-in-unit-tests-using-ambient-context-pattern/

            // Arrange - Setup DateTimeProvider mock
            var DateTimeProvider = new Mock<IDateTimeProvider>();
            var FakeDate = new DateTime(2020, 7, 4);
            DateTimeProvider.Setup(s => s.Today).Returns(FakeDate);

            // Act - Get Notice
            //  It feels weird to not pass the normally dependency-injected DateTimeProvider
            //  into the constructor. But, it makes sense for its normal use in a controller.
            var Notices = new NoticeCache();
            var result = Notices.GetNotice(DateTimeProvider.Object);

            // Assert
            Assert.AreEqual(result.IconLeft, "flagUSA");
            Assert.AreEqual(result.IconRight, "fireworks");
            Assert.AreEqual(result.StyleClass, "alert-primary");
            Assert.AreEqual(result.Messages.Length, 1);
        }

        [TestMethod]
        public void Notices_NoticeDoesNotExist()
        {
            // References for Moq use with dependency injection:
            // * https://github.com/Moq/moq4/wiki/Quickstart
            // * https://codopia.wordpress.com/2017/04/24/how-to-mock-up-datetime-now-in-unit-tests-using-ambient-context-pattern/

            // Arrange - Setup DateTimeProvider mock
            var DateTimeProvider = new Mock<IDateTimeProvider>();
            var FakeDate = new DateTime(2020, 7, 5);
            DateTimeProvider.Setup(s => s.Today).Returns(FakeDate);

            // Act - Get Notice
            //  It feels weird to not pass the normally dependency-injected DateTimeProvider
            //  into the constructor. But, it makes sense for its normal use in a controller.
            var Notices = new NoticeCache();
            var result = Notices.GetNotice(DateTimeProvider.Object);

            // Assert
            Assert.IsNull(result);
        }
    }
}
