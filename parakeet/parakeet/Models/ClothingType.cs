using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parakeet.Models
{
    public class ClothingType
    {
        public int ClothingTypeId { get; set; }
        public string type { get; set; }

        public String UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
