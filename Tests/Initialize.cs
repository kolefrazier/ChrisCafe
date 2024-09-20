using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChrisCafe.Data;
using ChrisCafe.Data.Caches;

namespace ChrisCafeTests
{
    [TestClass]
    public class Initialize
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            if (Cache.Notices == null || !Cache.Notices.Any())
                DataInitializer.InitializeAll();
        }
    }
}
