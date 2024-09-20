using ChrisCafe.Models.ViewModels;

namespace ChrisCafe.Data.Caches
{
    public class MenuCache
    {
        public FullMenu CachedFullMenu { get; private set; }

        public void Set(FullMenu fullMenu) =>
            CachedFullMenu = fullMenu;
    }
}
