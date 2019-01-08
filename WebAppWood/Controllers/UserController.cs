using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppWood.Models;
using System.Security.Cryptography;
using System.Text;

namespace WebAppWood.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        ModelUser user = new ModelUser();
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(FormCollection fc)
        {
            user.Username = fc["Username"];
            user.Name = fc["Name"];
            user.Password = encrypt(fc["Password"]);
            user.Role = Convert.ToInt32(fc["Role"]);
            user.CreateUser(user);
            return View();
        }
        public ActionResult ModifyUser() {
            return View();
        }
        [HttpPost]
        public ActionResult ModifyUser(FormCollection fc) {
            user.Username = fc["Username"];
            user.Name = fc["Name"];
            user.Password = encrypt(fc["Password"]);
            user.Role = Convert.ToInt32(fc["Role"]);
            user.ModifyUser(user);
            return View();
        }

        public string encrypt(string text) {
            string encryptedText = "";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] password = sha.ComputeHash(bytes);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in password)
                stringBuilder.AppendFormat("{0:X2}", b);
            return encryptedText = stringBuilder.ToString();
        }
    }
}