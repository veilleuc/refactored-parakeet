using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace parakeet.Models
{
    public class Size
    {
        public int SizeId { get; set; }

        [DisplayName("Size")]
        public String SizeName { get; set; }
    }
}
