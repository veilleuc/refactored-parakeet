using Microsoft.AspNetCore.Razor.Language.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parakeet.Models
{
    public class Design
    {
        public int DesignId { get; set; }

        public byte[] DesignArray { get; set; }

        public string DesignName { get; set; }

        public int Popularitycounter { get; set; }

        public bool Approved { get; set; }

        public bool AdminViewed { get; set; }

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
