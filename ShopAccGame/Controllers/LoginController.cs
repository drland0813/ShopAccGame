using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopAccGame.Models.MyData;
namespace ShopAccGame.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        MyDatabase db = new MyDatabase();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string email = collection.Get("email");
            string password = Encrytion.MD5Hash(collection.Get("password"));
            User_ user = db.User_.Where(m => m.email == email && m.password == password).FirstOrDefault();
            if(user != null)
            {
                Session.Add("USER_ID", user.user_id);
                Session.Add("fullname", user.fullname);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "Tên Đăng Nhập Hoặc Mật Khẩu Không Chính Xác !";
            return View();
        }
    }
}