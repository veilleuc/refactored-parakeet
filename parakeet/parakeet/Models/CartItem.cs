using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parakeet.Models
{
    public class CartItem
    {
        public Size Size { get; set; }

        public ClothingType ClothingType { get; set; }

        public Design Design { get; set; }
    }
}
