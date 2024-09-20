using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChrisCafe.Models.ViewModels
{
    public class FullMenu
    {
        public FullMenu()
        {
            BreakfastMenu = new MenuCategoryContainer()
            {
                Name = "Breakfast"
            };
            LunchMenu = new MenuCategoryContainer()
            {
                Name = "Lunch"
            };
            BeveragesMenu = new MenuCategoryContainer()
            {
                Name = "Beverages"
            };
        }

        public MenuCategoryContainer BreakfastMenu { get; set; }
        public MenuCategoryContainer LunchMenu { get; set; }
        public MenuCategoryContainer BeveragesMenu { get; set; }
        public bool ShowBreakfast { get; set; }
        public bool ShowLunch { get; set; }
        public bool ShowBeverages { get; set; }
    }
}
