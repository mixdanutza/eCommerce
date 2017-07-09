using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace ECommerce.Models
{
    public class Order: BaseEntity 
    {
      
        public int OrderId { get; set; }
        public int CustomerId {get; set;} 
        public Customer Customer {get; set;}
        public int ProductId {get; set;}
        public Product Product {get; set;}
        public int Quantity {get; set;}
        public Order(): base(){
            
        }


    }
}