using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChrisCafe.Models.ViewModels
{
    public class FullMenu
    {
        ////public List<MenuItem> MenuItems { get; set; }
        //public List<MenuItem> BreakfastMenuItems { get; set; }
        //public List<MenuItem> LunchMenuItems { get; set; }
        public List<SubcategoryItem> BreakfastMenu { get; set; }
        public List<SubcategoryItem> LunchMenu { get; set; }
        public bool ShowBreakfast { get; set; }
        public bool ShowLunch { get; set; }

        
    }
}
