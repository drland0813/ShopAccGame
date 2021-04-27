﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopAccGame.Models.MyData;
namespace ShopAccGame.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        private MyDatabase db = null;
        public RegisterController()
        {
            db = new MyDatabase();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string email = collection.Get("email");
            string fullname = collection.Get("fullname");
            string password = Encrytion.MD5Hash(collection.Get("password"));
            User_ user = new User_();
            user.fullname = fullname;
            user.email = email;
            user.password = password;
            user.user_role = 1;
            //hay là cái đây ông hong biết . Nhưng chắc k phải đâu 
            db.User_.Add(user);
            db.SaveChanges();
            ViewBag.Message = "Đăng Ký Thành Công";
            return Redirect("/Login");
        }

    }
}