using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class RegistrationController : Controller
    {
            private ECommerceContext _context;
        
            public RegistrationController(ECommerceContext context)
            {
                _context = context;
            }
            //Login registration view page 
            [HttpGet]
            [Route("")]
            public IActionResult Index()
            {
                return RedirectToAction("dashboard", "Dashboard");
            }

             //Login Registration Page Display
            [HttpGet]
            [Route("logreg")]
            public IActionResult logreg()
            {
                System.Console.WriteLine("*******");
                return View("Index");
            }

            //Registration process route
            [HttpPost]
            [Route("register")]
            public IActionResult register(UserViewModel NewUser, User MyNewUser)
            {
                // //Check database if there is a user with this emai already register
                List<User> get_user_email=_context.User.Where(email=>email.Email==NewUser.Email).ToList();
                List<string> error_list= new List<string>();
                if(ModelState.IsValid){
                    if(get_user_email.Count>0){
                        error_list.Add("An user with this email already exists try Login!");
                    }
                    if(NewUser.Password!=NewUser.ConfPassword){
                        error_list.Add("Confirmation Password does not match your Password!");
                    }
                    if(error_list.Count>0){
                        ViewBag.Errors=error_list;
                        return View("Index");
                    }
                    else{
                        //Hash the password
                        PasswordHasher<User> hashed = new PasswordHasher<User>();
                        MyNewUser.Password=hashed.HashPassword(MyNewUser, MyNewUser.Password);
                        //If everythin good and pass validations
                        _context.Add(MyNewUser);
                        _context.SaveChanges();
                        //Save the user_id in a session
                         User get_by_email=_context.User.SingleOrDefault(user=>user.Email==NewUser.Email);
                         HttpContext.Session.SetInt32("current_user_id", (int)get_by_email.UserId);
                         return RedirectToAction("dashboard", "Dashboard");
                    }
                }
                else{
                    return View("Index");
                }
            }

            //Login process route
            [HttpPost]
            [Route("login")]
            public IActionResult login(Login LogUser)
            {
                List<string> error_list= new List<string>();
                User get_by_email=_context.User.SingleOrDefault(user=>user.Email==LogUser.LogEmail);
                if(ModelState.IsValid){
                    if(get_by_email==null){
                        error_list.Add("You are not registered yet!");
                    }
                    if(error_list.Count>0){
                            ViewBag.Errors=error_list;
                            return View("Index");
                    }
                    else{
                        var hashed=new PasswordHasher<User>();
                        if(0==hashed.VerifyHashedPassword(get_by_email, get_by_email.Password, LogUser.LogPassword )){
                            error_list.Add("Your password is incorect!");
                        }
                        if(error_list.Count>0){
                            ViewBag.Errors=error_list;
                            return View("Index");
                        }
                        else{
                            HttpContext.Session.SetInt32("current_user_id", (int)get_by_email.UserId);
                            return RedirectToAction("dashboard", "Dashboard");
                        }
                    }
                }
                else{
                    return View("Index");
                }
            }

            //Logout route
            [HttpGet]
            [RouteAttribute("logout")]
            public IActionResult logout(){
                HttpContext.Session.Clear();
                return RedirectToAction("Index","Registration");
            }



            

        }
    }

