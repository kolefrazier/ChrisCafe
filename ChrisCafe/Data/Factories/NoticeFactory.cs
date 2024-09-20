using Newtonsoft.Json;
using ChrisCafe.Models;
using ChrisCafe.Models.ViewModels;

namespace ChrisCafe.Data.Factories
{
    public class NoticeFactory
    {
        private static readonly string[] DEFAULT_NOTICES_PATH = { "RawData", "Notices.json" };
        public string NoticesFilePath { get; private set; }

        /// <summary>
        /// Instantiates an instance of NoticeFactory.
        /// Uses the default path of /RawData/Notices.json.
        /// </summary>
        /// <param name="noticesPathOverride">Overrides the default notices path.</param>
        public NoticeFactory(string[] noticesPathOverride = null)
        {
            NoticesFilePath = (noticesPathOverride == null || noticesPathOverride.Length == 0)
                ? Path.Combine(DEFAULT_NOTICES_PATH)
                : Path.Combine(noticesPathOverride);
        }

        public Dictionary<string, Notice> Setup()
        {
            List<NoticeRaw> RawNotices = ImportNoticeData();
            var Notices = new Dictionary<string, Notice>();

            foreach (NoticeRaw raw in RawNotices)
            {
                string key = string.Concat(raw.Month, "-", raw.Day);
                if (!Notices.ContainsKey(key))
                    Notices.Add(key, new Notice(raw.StyleClass, raw.Messages, raw.IconLeft, raw.IconRight));
            }

            return Notices;
        }

        private List<NoticeRaw> ImportNoticeData()
        {
            string NoticesRaw = File.ReadAllText(NoticesFilePath);
            return JsonConvert.DeserializeObject<List<NoticeRaw>>(NoticesRaw);
        }
    }
}
