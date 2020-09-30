using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parakeet.Models
{
    // CLOTHING TYPE DB SEED DATA CAN BE FOUND IN ApplicationDBContext.cs
    public class ClothingType
    {
        public int ClothingTypeId { get; set; }
        public string type { get; set; }

        public float price { get; set; }

        
    }
}
