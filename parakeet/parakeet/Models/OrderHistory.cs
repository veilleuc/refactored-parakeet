using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parakeet.Models
{
    public class OrderHistory
    {
        public int OrderHistoryId { get; set; }

        public DateTime OrderDate { get; set; }

        public int ClothingTypeId { get; set; }

        public virtual ClothingType ClothingType { get; set; }
    }
}
