using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace ECommerce.Models
{
    public class Login 
    {
        [RequiredAttribute]
        public string LogEmail { get; set; }
        [RequiredAttribute]
        public string LogPassword { get; set; }


    }
}