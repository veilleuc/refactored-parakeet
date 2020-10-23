using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parakeet.Models
{
    public class ProductsViewModel
    {
        public Design[] designs { get; set; }

        public ClothingType[] clothingTypes { get; set; }

        public Size[] sizes { get; set; }

        public string ClothingTypes { get; set; }

        public string Sizes { get; set; }

        public string Designs { get; set; }
    }
}
