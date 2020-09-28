using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ChrisCafe.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }

        /* Foreign Keys (Singular Navigation Properties) */
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int SubcategoryId { get; set; }

        public int FlagsId { get; set; }

        /* Model Properties */
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [StringLength(100, ErrorMessage = "Short Description cannot be longer than 100 characters.")]
        public string DescriptionShort { get; set; }

        
        public double Price { get; set; }
        public double SecondPrice { get; set; } //Useful for items with Half and Full orders (e.g. pancakes and combination plates)

        [Required]
        public int DisplayOrder { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "MM/dd/yyyy")]
        public DateTime DateAdded { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "MM/dd/yyyy hh:mm tt")]
        public DateTime DateLastModified { get; set; }
    }
}
