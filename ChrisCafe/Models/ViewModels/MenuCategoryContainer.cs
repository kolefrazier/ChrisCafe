using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChrisCafe.Models.ViewModels
{
    public class MenuCategoryContainer
    {
        public MenuCategoryContainer()
        {
            Items = new List<SubcategoryItem>();
        }

        public string Name { get; set; }
        public List<SubcategoryItem> Items { get; set; }
    }
}
