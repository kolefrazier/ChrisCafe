using ChrisCafe.Models.ViewModels;
using ChrisCafe.Data.Factories;
using ChrisCafe.Data.Caches;
using ChrisCafe.Models.Catering;

namespace ChrisCafe.Data
{
    public static class DataInitializer
    {
        public static void InitializeAll(string[] noticesPathOverride = null)
        {
            InitializeMenu();
            InitializeCateringMenu();
            InitializeNotices(noticesPathOverride);
        }

        private static void InitializeMenu()
        {
            var Factory = new MenuFactory();
            FullMenu GeneratedMenu = Factory.Setup();
            Cache.Menu.Set(GeneratedMenu);
        }

        private static void InitializeCateringMenu()
        {
            var Factory = new CateringMenuFactory();
            CateringMenu GeneratedMenu = Factory.Setup();
            Cache.CateringMenu.Set(GeneratedMenu);
        }

        private static void InitializeNotices(string[] noticesPathOverride = null)
        {
            var Factory = new NoticeFactory(noticesPathOverride);
            Dictionary<string, Notice> Notices = Factory.Setup();
            Cache.Notices.Set(Notices);
        }
    }
}
