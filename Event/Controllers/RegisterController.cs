using Event.Data;
using Event.Models;
using Event.Models.Entity;
using Event.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Event.Utility.QueryHandler;
namespace Event.Controllers
{
    public class RegisterController : Controller
    {
        private readonly MyDbContext _dbContext;
        //private readonly QueryHandler _queryHandler;


        public RegisterController(MyDbContext context)
        {

            _dbContext = context;


        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration( RegistrationViewModel model)
        {

            if (ModelState.IsValid)
            {
                bool UserExist = _dbContext.Registration.Any(x => x.Email == model.Email);


                if (UserExist)
                {

                    ModelState.AddModelError(nameof(model.Email), "Email already exists");
                    return View();


                }

                int rowsAffected = QueryHandler.Instance.Register(model.Name,
                                                         model.Password,
                                                         model.Email,
                                                         model.BusinessName,
                                                         model.PhoneNumber,
                                                         model.ModeOfBusiness,
                                                         model.Category);
                    if (rowsAffected > 0)
                    {
                        TempData["Error"] = "Registered successfully.";
                        return RedirectToAction("Registration"); // Redirect to a success page or to where you need to go next
                    }
                    else
                    {
                        TempData["Error"] = "Failed to register.";
                        return View(model); // Return to the view with error message if creation failed
                    }
                
                //bool UserExist = _dbContext.Registration.Any(x => x.Email == model.Email);
                //if (UserExist)
                //{
                //    return RedirectToAction("Index", "Home");


                //}
                //  QueryHandler,Instance.CreateVendor(pass args-reg data)
                

                //var reg = new Register
                //{
                //    Name = model.Name,
                //    Password = model.Password,
                //    Email = model.Email,
                //    BusinessName = model.BusinessName,
                //    PhoneNumber = model.PhoneNumber,
                //    ModeOfBusiness = model.ModeOfBusiness,
                //    Category = model.Category,

                //};
                
                // Map view model to entity model
              

                //// Add to database
                //_dbContext.Registration.Add(reg);
                //_dbContext.SaveChanges();
                //ModelState.Clear();

                //TempData["Error"] = "Registered Successfully";

                //return View();
            }

            return View(model);
        }

       
    }
}
