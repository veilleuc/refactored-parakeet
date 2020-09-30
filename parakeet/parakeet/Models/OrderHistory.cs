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

        public int DesignId { get; set; }

        
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ClothingType ClothingType { get; set; }

        public virtual Design Design { get; set; }
    }
}
