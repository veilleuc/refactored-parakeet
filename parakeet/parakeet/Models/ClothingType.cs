using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace parakeet.Models
{
    // CLOTHING TYPE DB SEED DATA CAN BE FOUND IN ApplicationDBContext.cs
    public class ClothingType
    {
        public int ClothingTypeId { get; set; }
        [Display(Name = "Clothing Type")]
        public string type { get; set; }

        public float price { get; set; }

        
    }
}
