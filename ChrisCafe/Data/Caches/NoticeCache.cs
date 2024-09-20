using ChrisCafe.Providers;
using ChrisCafe.Models.ViewModels;

namespace ChrisCafe.Data.Caches
{
    public class NoticeCache
    {
        private Dictionary<string, Notice> Notices { get; set; }
        
        public void Set(Dictionary<string, Notice> notices) =>
            Notices = notices;

        /// <summary>
        /// Tries to get a notice for the given day, based on DateTime.Today.
        /// This method takes in an IDateTimeProvider (rather than the ctor) to prevent
        ///     repeated disk reads and parsing. That way, controllers get the provider injected
        ///     and pass the injected instance to this method. (Bit ugly, but I'm going with it for now.)
        /// </summary>
        /// <returns>Notice view model if notice is found, otherwise null.</returns>
        public Notice GetNotice(IDateTimeProvider dateTimeProvider)
        {
            //MSDN confirms that DateTime.Today.Month and Day are 1-based. (Month: 1-12, Day: 1-31)
            string key = string.Concat(dateTimeProvider.Today.Month, "-", dateTimeProvider.Today.Day);
            return (Notices.ContainsKey(key)) ? Notices[key] : null;
        }

        // Utility method, intended for use in tests to verify if the cache is setup
        public bool Any()
        {
            return Notices != null && Notices.Keys.ToList().Count > 0;
        }
    }
}
