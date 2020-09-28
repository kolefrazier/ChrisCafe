using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChrisCafe.Models.ViewModels
{
    public class SubcategoryItem
    {
        public int SubcategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MenuItem> Items { get; set; }
    }
}
