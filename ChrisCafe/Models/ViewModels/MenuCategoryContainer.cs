using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChrisCafe.Models.ViewModels
{
    public class MenuCategoryContainer
    {
        public string Name { get; set; }
        public List<SubcategoryItem> CategorizedItems { get; set; }
    }
}
