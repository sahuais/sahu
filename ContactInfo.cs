using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactInfoMaintain.Models
{
    public class ContactInfo
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "Please Enter First Name")]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }



        [Required(ErrorMessage = "Please Enter Email Address")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
         ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }
        

        
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }



        [Required(ErrorMessage = "Please select Status")]
        public bool Status { get; set; }
    }

}