using ChrisCafe.Models.Catering;

namespace ChrisCafe.Data.Caches
{
    public class CateringMenuCache
    {
        public CateringMenu Menu { get; private set; }

        public void Set(CateringMenu cateringMenu) =>
            Menu = cateringMenu;
    }
}
