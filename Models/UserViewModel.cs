using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class UserViewModel : BaseEntity
    {
        [Required]
        [MinLength(3, ErrorMessage="Your first name has to be at least 3 characters long!")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage="Your last name has to be at least 3 characters long!")]
        public string LastName { get; set; }

        [Required]
        [RegularExpressionAttribute(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage="Your email has to contain a (@) and (.)!")]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required]
        [MinLength(6, ErrorMessage="You password has to be at least 6 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string ConfPassword { get; set; }

        

    }
}