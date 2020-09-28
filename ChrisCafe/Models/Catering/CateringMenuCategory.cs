using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChrisCafe.Models.Catering
{
    public class CateringMenuCategory
    {
        public string Name { get; set; }
        public List<CateringMenuItem> MenuItems { get; set; }
        public int DisplayOrder { get; set; }
        public CateringMenuCategory()
        {
            MenuItems = new List<CateringMenuItem>();
        }
    }
}
