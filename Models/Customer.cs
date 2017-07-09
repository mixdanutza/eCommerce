using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace ECommerce.Models
{
    public class Customer : BaseEntity
    {
        [KeyAttribute]
        public int CustomerId {get; set;}
        [RequiredAttribute(ErrorMessage="Please add a Customer name!")]
        public string CustomerName { get; set; }
        public List<Order> Orders {get;set;}
        public Customer(){
            Orders=new List<Order>();
        }

    }
}