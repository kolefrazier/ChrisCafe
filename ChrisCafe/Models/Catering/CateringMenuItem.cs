using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChrisCafe.Models.Catering
{
    public class CateringMenuItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int DisplayOrder { get; set; }
        public double? Price { get; set; }
        public string ServingSize { get; set; }
        //public string Description { get; set; }
        public string[] AdditionalServingCosts { get; set; }
        public List<CateringMenuItemParts> MenuItemParts { get; set; }

        public CateringMenuItem()
        {
            AdditionalServingCosts = new string[0];
        }
    }
}