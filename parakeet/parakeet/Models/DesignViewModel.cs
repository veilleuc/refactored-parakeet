using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace parakeet.Models
{
    public class DesignViewModel
    {
        public int DesignId { get; set; }

        // image that has been converted to byte array
        public IFormFile DesignArray { get; set; }

        [Display(Name = "Design")]
        public string DesignName { get; set; }

        public int Popularitycounter { get; set; }

        // makes these optional (?) for time being so that images can be viewed without approval
        public bool? Approved { get; set; }

        public bool? AdminViewed { get; set; }

        // filter tags
        public bool NatureTag { get; set; }

        public bool FunnyTag { get; set; }

        public bool AbstractTag { get; set; }

        public bool GameTag { get; set; }

        public bool MusicTag { get; set; }

        public bool MovieTag { get; set; }

        public bool CoolTag { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
