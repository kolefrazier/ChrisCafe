using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChrisCafe.Models.Catering
{
    public class CateringMenuItemParts
    {
        //public int? Quantity { get; set; }       //Quantity moved into description due to some items (Danishes...) having mixed quantity/descriptors: "10/8 Danishes/croissants."
        public string Description { get; set; }    //Description will handle all text content of an entry, as it can be a (inclusive or) name, quantity, description. And I really don't want to program both in.
        public double? Price { get; set; }         //Not all entries have a price.
    }
}
