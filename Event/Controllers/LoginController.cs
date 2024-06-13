using Event.Data;
using Event.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Event.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Ocsp;
using Microsoft.AspNetCore.Authorization;
using Event.Utility;

namespace Event.Controllers
{
    public class LoginController : Controller
    {
        private readonly MyDbContext _dbContext;



        public LoginController(MyDbContext context)
        {

            _dbContext = context;

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel credentials)
        {
            //bool UserExist = _dbContext.Registration.Any(x => x.Email == credentials.Email && x.Password == credentials.Password);


            //if (UserExist)
            //{

            //    return RedirectToAction("Index", "Home");


            //}
            bool UserExist = QueryHandler.Instance.Login(credentials.Email, credentials.Password);
            if (UserExist)
            {
                //TempData["Error"] = "User is logged in!";
                return RedirectToAction("Index", "Home");
            }
            TempData["Error"] = "Wrong credentials,Please try again!";
            return View();
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

    

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPassword)
        {
            if (!ModelState.IsValid)
            {

                return View(forgotPassword);

            }
            bool UserExist = QueryHandler.Instance.Forgot(forgotPassword.Email);
            if (UserExist)
            {
                TempData["Error"] = "Email Exists!";
                

               
            }
            else
            {
                TempData["Error"] = "Email not exist!";

            }
            var token = GenerateResetToken();
            var resetLink = Url.Action("ResetPassword", "Login", new { Email = forgotPassword.Email, token = token }, Request.Scheme);
            await SendResetEmail(forgotPassword.Email, resetLink);
            TempData["Error"] = "We had a sent a link to reset password to your email id.";
            return View();
            //var user = await _dbContext.Registration.FirstOrDefaultAsync(x => x.Email == forgotPassword.Email);
            //if (user != null)
            //{
            //    var token = GenerateResetToken();
            //    var resetLink = Url.Action("ResetPassword", "Login", new { Email = forgotPassword.Email, token = token }, Request.Scheme);
            //    await SendResetEmail(user.Email, resetLink);

            //}


        }



        private async Task SendResetEmail(string email, string resetLink)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com");

            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("anjujohn206@gmail.com", "vqnl eroo cyak gdqc");
            var message = new MailMessage
            {
                From = new MailAddress("anjujohn206@gmail.com"),
                Subject = "Password Reset",
                Body = $"Click the following link to reset your password: {resetLink}"
            };
            message.To.Add(email);
            await smtpClient.SendMailAsync(message);
        }

        private string GenerateResetToken()
        {
            var token = Guid.NewGuid().ToString();

            _dbContext.SaveChanges();

            return token;
        }
      

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string Email)
        {
            if (token == null && Email == null)
            {
                ModelState.AddModelError("", "invalid reset password token");
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                //getting user from database 
                //var user = await _dbContext.Registration.FirstOrDefaultAsync(a => a.Email == model.Email);
                //if (user != null)
                //{
                //    user.Password = model.Password;
                //    await _dbContext.SaveChangesAsync();
                //}

                bool user = QueryHandler.Instance.Reset(model.Email, model.Password);
                if (user)
                {
                    TempData["Error"] = "Updated successfully";
                }


            }
           
            return RedirectToAction("Login", "Login");


        }

    }

}

