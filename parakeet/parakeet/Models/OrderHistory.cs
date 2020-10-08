using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace parakeet.Models
{
    public class OrderHistory
    {
        public int OrderHistoryId { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderItemHistory> OrderItemHistory { get; set; }
        
        public virtual ApplicationUser ApplicationUser { get; set; }
       
    }
}
