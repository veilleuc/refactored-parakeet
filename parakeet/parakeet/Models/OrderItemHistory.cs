using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parakeet.Models
{
    public class OrderItemHistory
    {
        public int OrderItemHistoryId { get; set; }

        public int OrderHistoryId { get; set; }

        public int DesignId { get; set; }

        public int ClothingTypeId { get; set; }

        public int SizeId { get; set; }

        public virtual OrderHistory OrderHistory { get; set; }

        public virtual Design Design { get; set; }

        public virtual ClothingType ClothingType { get; set; }

        public virtual Size Size { get; set; }


    }
}
