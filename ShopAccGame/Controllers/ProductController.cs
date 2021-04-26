using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopAccGame.Models.DataRequester;
using ShopAccGame.Models.MyData;
namespace ShopAccGame.Controllers
{
    public class ProductController : Controller
    {

        public static readonly string[] RANKS = new string[]
        {
            "Iron",
            "Copper",
            "Silver",
            "Gold",
            "Platinum",
            "Diamond",
            "Master",
            "Grand Master",
            "Challenger",
            "Rankless"
        };

        // GET: Product
        public ActionResult Index()
        {

            AccountDAO accountDAO = new AccountDAO();
            ICollection<Account> lolAccounts = accountDAO.getListAccounts();
            ViewData["lolAccounts"] = lolAccounts;
            ViewData["ranks"] = RANKS;
            return View();
        }
    }
}