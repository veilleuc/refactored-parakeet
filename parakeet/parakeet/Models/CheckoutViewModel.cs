using parakeet.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace parakeet.Models
{
    public class CheckoutViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_ ]*$",
         ErrorMessage = "Please Enter Valid Address")]
        [StringLength(100, ErrorMessage = "Please enter valid Address.", MinimumLength = 1)]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$",
         ErrorMessage = "Please Enter Valid Zip Code")]
        [StringLength(5, ErrorMessage = "Please Enter Valid 5 digit Zip Code", MinimumLength = 5)]
        public string Zipcode { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]*$",
         ErrorMessage = "Please Enter Valid City")]
        [StringLength(100, ErrorMessage = "Please enter valid City.", MinimumLength = 1)]
        public string City { get; set; }

        [Required]
        //[StringLength(2, ErrorMessage = "Please use the 2 Letter Shortened version of your State.", MinimumLength = 2)]
        //[RegularExpression(@"^[a-zA-Z]*$",
         //ErrorMessage = "Please Enter Valid State")]

        public State State { get; set; }

    }
}
