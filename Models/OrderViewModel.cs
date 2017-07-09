using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace ECommerce.Models
{
    public class OrderViewModel: BaseEntity 
    {
     
        [RequiredAttribute(ErrorMessage="Please select a customer!")]
        public int CustomerId {get; set;} 

        public Customer Customer {get; set;}

        [RequiredAttribute(ErrorMessage="Please select a product!")]
        public int ProductId {get; set;}

        public Product Product {get; set;}


        [RequiredAttribute(ErrorMessage="Please select quantity!")]
        public int Quantity {get; set;}



    }
}