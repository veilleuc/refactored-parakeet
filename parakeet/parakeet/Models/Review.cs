using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parakeet.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        public int Rating { get; set; }

        public string ReviewText { get; set; }

        public bool Approved { get; set; }

        public bool AdminViewed { get; set; }

        public int ClothingTypeId { get; set; }

        public virtual ClothingType ClothingType { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }


    }
}
