using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace ECommerce.Models
{
    public class ProductViewModel : BaseEntity
    {
        [RequiredAttribute(ErrorMessage="Please add a name!")]
        public string ProductName { get; set; }
        [RequiredAttribute(ErrorMessage="Please add an url!")]
        public string ProductUrl { get; set; }
        [RequiredAttribute(ErrorMessage="Please add a description!")]
        public string ProductDescription { get; set; }
        [RequiredAttribute(ErrorMessage="Please add quantity!")]
        public int ProductQuantity { get; set; }


    }
}