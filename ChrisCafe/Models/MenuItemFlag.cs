using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChrisCafe.Models
{
    //Created as a class to allow a one-to-one between MenuItem and Flags. 
    //  That way, any associated MenuItems can have specific flag settings for that item.
    public class MenuItemFlag
    {
        [Key]
        public int MenuItemFlagId { get; set; }

        /* Foreign Keys and Navigation Properties */
        [Required]
        public int MenuItemId { get; set; }

        [Required]
        public bool Spicy { get; set; }

        [Required]
        public bool Vegan { get; set; }

        [Required]
        public bool Vegetarian { get; set; }

        [Required]
        public bool Favorite { get; set; }

        [Required]
        public bool AllergyWarning { get; set; }
    }
}
