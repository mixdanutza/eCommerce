using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace ECommerce.Models
{
    public class Product : BaseEntity
    {
        public int ProductId {get; set;}
        public string ProductName { get; set; }
        public string ProductUrl { get; set; }
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }
        public List<Order> Order {get;set;} 
        public List<Customer> Customers {get; set;}
        public Product(){
            Order=new List<Order>();
            Customers=new List<Customer>();
        }


    }

}