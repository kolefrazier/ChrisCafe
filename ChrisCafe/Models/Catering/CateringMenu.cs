using ChrisCafe.Data.Caches;
using ChrisCafe.Data.Factories;

namespace ChrisCafe.Models.Catering
{
    public class CateringMenu
    {
        //Properties
        public string[] Categories { get; private set; }
        public List<CateringMenuCategory> MenuItems { get; set; }

        //Constructor
        public CateringMenu()
        {
            Categories = CateringMenuFactory.Categories;
            MenuItems = new List<CateringMenuCategory>();
        }
    }
}
