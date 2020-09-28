using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChrisCafe.Data;

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
            Categories = ChrisCafe.Data.Cache.CateringMenu.Categories;
            MenuItems = new List<CateringMenuCategory>();
        }
    }
}
