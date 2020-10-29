using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace parakeet.Models
{
    public class ProductsViewModel
    {
        //array to search to input all the types into for printing and values
        public Design[] designs { get; set; }

        public ClothingType[] clothingTypes { get; set; }

        public Size[] sizes { get; set; }

        //values for buttons in the Products view index
        [Required]
        public string ClothingTypes { get; set; }
        [Required]
        public string Sizes { get; set; }
        [Required]
        public int Designs { get; set; }
    }
}
