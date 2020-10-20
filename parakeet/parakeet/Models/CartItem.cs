using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parakeet.Models
{
    public class CartItem
    {
        public Size size { get; set; }

        public ClothingType clothingType { get; set; }

        public Design design { get; set; }
    }
}
