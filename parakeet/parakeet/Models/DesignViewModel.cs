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
        [Required]
        [Display(Name = "Your Design")]
        public IFormFile DesignArray { get; set; }

        [Required]
        [Display(Name = "Design Name")]
        [StringLength(20, ErrorMessage = "Name length can not exceed 20 characters.")]
        public string DesignName { get; set; }

        public int Popularitycounter { get; set; }

        // makes these optional (?) for time being so that images can be viewed without approval
        
        public bool? Approved { get; set; }

        public bool? AdminViewed { get; set; }

        // filter tags
        [Display(Name = "Nature")]
        public bool NatureTag { get; set; }

        [Display(Name = "Funny")]
        public bool FunnyTag { get; set; }

        [Display(Name = "Abstract")]
        public bool AbstractTag { get; set; }

        [Display(Name = "Game")]
        public bool GameTag { get; set; }

        [Display(Name = "Music")]
        public bool MusicTag { get; set; }

        [Display(Name = "Movie")]
        public bool MovieTag { get; set; }

        [Display(Name = "Cool")]
        public bool CoolTag { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
