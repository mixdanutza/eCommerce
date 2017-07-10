using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ECommerce.Models;

namespace wedding_planner.Controllers
{
    public class DashboardController : Controller
    {
            private ECommerceContext _context;
        
            public DashboardController(ECommerceContext context)
            {
                _context = context;
            }

            //Display Dashboard
            [HttpGet]
            [Route("dashboard")]
            public IActionResult dashboard()
            {
                // if(HttpContext.Session.GetInt32("current_user_id")==null){
                //     List<string> error_list=new List<string>();
                //     error_list.Add("Don't try to steal my cookies!");
                //     ViewBag.Errors=error_list;
                //     return View("../Registration/Index");
                // }
                // else{
                //     int UserInSession=HttpContext.Session.GetInt32("current_user_id") ??default(int);
                //     ViewBag.UserInSession=UserInSession;        
                    //5 Most Pupular products
                    List<Product> LastProducts=_context.Product.OrderByDescending(pr=>pr.created_at).Take(4).ToList();    
                    ViewBag.LastProducts=LastProducts;   
                    //3 Most Recent orders
                    List<Order> LastOrders=_context.Order.Include(o=>o.Customer).Include(or=>or.Product).OrderByDescending(pr=>pr.created_at).Take(3).ToList();    
                    ViewBag.LastOrders=LastOrders; 
                    //3 Most Recent customers
                    List<Customer> LastCustomers=_context.Customer.OrderByDescending(pr=>pr.created_at).Take(3).ToList();    
                    ViewBag.LastCustomers=LastCustomers;   
                    User last=_context.User.OrderByDescending(x=>x.created_at).Take(1).SingleOrDefault();
                    System.Console.WriteLine("******************************88"); 
                    // Console.WriteLine(last.TimeAgo());      
                    return View("dashboard");
                // }
            }

            //Display Products
            [HttpGet]
            [Route("ProductsPage")]
            public IActionResult ProductsPage()
            {
                // if(HttpContext.Session.GetInt32("current_user_id")==null){
                //     List<string> error_list=new List<string>();
                //     error_list.Add("Don't try to steal my cookies!");
                //     ViewBag.Errors=error_list;
                //     return View("../Registration/Index");
                // }
                // else{
                //     int UserInSession=HttpContext.Session.GetInt32("current_user_id") ??default(int);
                    List<Product> AllProducts=_context.Product.ToList();
                    // ViewBag.UserInSession=UserInSession;  
                    ViewBag.Errors=TempData["Errors"];
                    ViewBag.AllProducts=AllProducts;            
                    return View("products");
                // }
            }
            //Add Product to database
            [HttpPost]
            [Route("AddProduct")]
            public IActionResult AddProduct(Product NewProduct, ProductViewModel MyNewproduct)
            {
                List<string> error_list= new List<string>();
                if(ModelState.IsValid){
                    _context.Product.Add(NewProduct);
                    _context.SaveChanges();
                    return RedirectToAction("ProductsPage");
                }else{
                    foreach(var error in ModelState.Values){
                        if(error.Errors.Count>0){
                            error_list.Add(error.Errors[0].ErrorMessage.ToString());
                        }
                    }
                    TempData["Errors"]=error_list;
                    return RedirectToAction("ProductsPage");                
                }
            }











            //Display Orders
            [HttpGet]
            [Route("OrdersPage")]
            public IActionResult OrdersPage()
            {
                // if(HttpContext.Session.GetInt32("current_user_id")==null){
                //     List<string> error_list=new List<string>();
                //     error_list.Add("Don't try to steal my cookies!");
                //     ViewBag.Errors=error_list;
                //     return View("../Registration/Index");
                // }
                // else{
                    // int UserInSession=HttpContext.Session.GetInt32("current_user_id") ??default(int);
                    List <Customer> AllCustomers=_context.Customer.ToList();
                    ViewBag.AllCustomers=AllCustomers;
                    List <Product> AllProducts=_context.Product.ToList();
                    ViewBag.AllProducts=AllProducts;     
                    List<Order> Ord=_context.Order.Include(prod=>prod.Product).Include(p=>p.Customer).ToList();     
                    ViewBag.Included=Ord;     
                    // ViewBag.UserInSession=UserInSession;  
                    ViewBag.Errors=TempData["Errors"];             
                    return View("orders");
                // }
            }
            //Add Order to database
            [HttpPost]
            [Route("AddOrder")]
            public IActionResult AddOrder(Order NewOrder, OrderViewModel MyNewOrder)
            {
                Product GetProd=_context.Product.SingleOrDefault(p=>p.ProductId==NewOrder.ProductId);
                List<string> error_list= new List<string>();
                if(ModelState.IsValid){
                    if(GetProd.ProductQuantity>=NewOrder.Quantity){
                        Order AddOrder=new Order{
                            CustomerId=NewOrder.CustomerId,
                            ProductId=NewOrder.ProductId,
                            Quantity=NewOrder.Quantity,
                        };
                        _context.Order.Add(AddOrder);
                        GetProd.ProductQuantity-=NewOrder.Quantity;
                        _context.SaveChanges();
                        return RedirectToAction("OrdersPage");
                        }else{
                            error_list.Add("Soryy, There are only "+GetProd.ProductQuantity+ " left");
                            TempData["Errors"]=error_list;
                            return RedirectToAction("OrdersPage");
                        }
                }else{
                    foreach(var error in ModelState.Values){
                        if(error.Errors.Count>0){
                            error_list.Add(error.Errors[0].ErrorMessage.ToString());
                        }
                    }
                    TempData["Errors"]=error_list;
                    return RedirectToAction("OrdersPage");                
                }
            }












            //Display Customers
            [HttpGet]
            [Route("CustomersPage")]
            public IActionResult CustomersPage()
            {
                // if(HttpContext.Session.GetInt32("current_user_id")==null){
                //     List<string> error_list=new List<string>();
                //     error_list.Add("Don't try to steal my cookies!");
                //     ViewBag.Errors=error_list;
                //     return View("../Registration/Index");
                // }
                // else{
                    // int UserInSession=HttpContext.Session.GetInt32("current_user_id") ??default(int);
                    List <Customer> AllCustomers=_context.Customer.ToList();
                    // ViewBag.UserInSession=UserInSession;  
                    ViewBag.Errors=TempData["Errors"]; 
                    ViewBag.AllCustomers=AllCustomers;           
                    return View("customers");
                // }
            }
            //Add customer to database
            [HttpPost]
            [RouteAttribute("AddCustomer")]
            public IActionResult AddCustomer(Customer NewCustomer){
                List<string> error_list= new List<string>();
                if(ModelState.IsValid){
                    _context.Customer.Add(NewCustomer);
                    _context.SaveChanges();
                    return RedirectToAction("CustomersPage");
                }else{
                    foreach(var error in ModelState.Values){
                        if(error.Errors.Count>0){
                            error_list.Add(error.Errors[0].ErrorMessage.ToString());
                        }
                    }
                    TempData["Errors"]=error_list;
                    return RedirectToAction("CustomersPage");                
                }
            }
            //delete customer from database
            [HttpPost]
            [RouteAttribute("DeleteCustomer/{id}")]
            public IActionResult DeleteCustomer(int id){
                Customer GetCustomer=_context.Customer.SingleOrDefault(cust => cust.CustomerId==id);
                _context.Remove(GetCustomer);
                _context.SaveChanges();
                return RedirectToAction("CustomersPage");                                
            }

            
    }
}