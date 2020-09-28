using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using ChrisCafe.Models;
using Microsoft.AspNetCore.Html;
using ChrisCafe.Data.Providers;

namespace ChrisCafe.Data
{
    public class NoticeCache
    {
        public NoticeCache()
        {
            IsCacheSet = false;
            Notices = new Dictionary<string, Models.ViewModels.Notice>();
        }

        private bool IsCacheSet { get; set; }
        private Dictionary<string, Models.ViewModels.Notice> Notices;

        public void Setup() =>
            PopulateFromRawJson();

        private void PopulateFromRawJson()
        {
            string NoticesFile = Path.Combine("RawData", "Notices.json");
            string NoticesRaw = File.ReadAllText(NoticesFile);
            List<NoticeRaw> RawNotices = JsonConvert.DeserializeObject<List<NoticeRaw>>(NoticesRaw);
            foreach(NoticeRaw raw in RawNotices)
            {
                string key = string.Concat(raw.Month, "-", raw.Day);
                if(!Notices.ContainsKey(key))
                    Notices.Add(key, new Models.ViewModels.Notice(raw.StyleClass, raw.Messages, raw.IconLeft, raw.IconRight));
            }

            IsCacheSet = true;
        }

        /// <summary>
        /// Tries to get a notice for the given day, based on DateTime.Today.
        /// This method takes in an IDateTimeProvider (rather than the ctor) to prevent
        ///     repeated disk reads and parsing. That way, controllers get the provider injected
        ///     and pass the injected instance to this method. (Bit ugly, but I'm going with it for now.)
        /// </summary>
        /// <returns>Notice view model if notice is found, otherwise null.</returns>
        public Models.ViewModels.Notice GetNotice(IDateTimeProvider dateTimeProvider)
        {
            if (!IsCacheSet)
                Setup();

            //MSDN confirms that DateTime.Today.Month and Day are 1-based. (Month: 1-12, Day: 1-31)
            string key = string.Concat(dateTimeProvider.Today.Month, "-", dateTimeProvider.Today.Day);
            return (Notices.ContainsKey(key)) ? Notices[key] : null;
        }

    }
}
