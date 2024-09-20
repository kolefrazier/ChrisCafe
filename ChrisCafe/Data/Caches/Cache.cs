namespace ChrisCafe.Data.Caches
{
    public static class Cache
    {
        public static MenuCache Menu { get; } = new MenuCache();
        public static CateringMenuCache CateringMenu { get; } = new CateringMenuCache();
        public static NoticeCache Notices { get; } = new NoticeCache();
    }
}
