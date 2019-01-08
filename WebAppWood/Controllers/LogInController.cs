using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebAppWood.Models;

namespace WebAppWood.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        ModelUser user = new ModelUser();
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(FormCollection fc)
        {
            user.Username = fc["Username"];
            user.Password = encrypt(fc["Password"]);
            if (VerifyPassword(user) == true) {
               return RedirectToAction("Dashboard", "Dashboard");
            }
            return View();
        }
        public string encrypt(string text)
        {
            string encryptedText = "";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] password = sha.ComputeHash(bytes);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in password)
                stringBuilder.AppendFormat("{0:X2}", b);
            return encryptedText = stringBuilder.ToString();
        }
        public bool VerifyPassword(ModelUser verify) {
           return user.ValidatePassword(verify.Username, verify.Password);
        }
    }
}