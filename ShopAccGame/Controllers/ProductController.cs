using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopAccGame.Models.DataRequester;
using ShopAccGame.Models.MyData;
using PayPal.Api;
//using Microsoft.Extensions.Configuration;
//using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using Payment = PayPal.Api.Payment;
using ShopAccGame.Models;
using ShopAccGame.Models.MyData;

namespace ShopAccGame.Controllers
{
    public class ProductController : Controller
    {
        private readonly string _clientId;
        private readonly string _secretKey;
        public static readonly string[] ranks = new string[]
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
            ViewData["ranks"] = ranks;
            return View("Index");
        }


        private Payment payment;
        private Payment CreatePayment(APIContext apiContext, string redirectUrl, Account account)
        {
            var listItems = new ItemList()
            {
                items = new List<Item>()
            };
            AccountDAO accountDAO = new AccountDAO();
            ICollection<Account> lolAccounts = accountDAO.getListAccounts();

            foreach (var cart in lolAccounts)
            {
                if (cart.account_id.ToString() == @Session["lolAccounts"])
                {
                    listItems.items.Add(new Item()
                    {
                        name = cart.account_name,
                        currency = "USD",
                        price = cart.sale_price.ToString(),
                        sku = "sku"
                    });
                }
            }


            var payer = new Payer() { payment_method = "paypal" };

            var redirUrl = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl
            };



            var details = new Details()
            {
                tax = "0",
                shipping = "0",
                subtotal = ((account.sale_price)*10).ToString()
            };

            var amount = new Amount()
            {
                currency = "USD",
                total = (Convert.ToDouble(details.tax) + Convert.ToDouble(details.shipping) + Convert.ToDouble(details.subtotal)).ToString(),
                details = details
            };

            var transactionList = new List<Transaction>();
            transactionList.Add(new Transaction()
            {
                description = "Thien testing transaction description",
                invoice_number = Convert.ToString((new Random()).Next(100000)),
                amount = amount,
                item_list = listItems
            });

            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrl
            };
            return payment.Create(apiContext);
        }


        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId,
            };
            payment = new Payment() { id = paymentId };
            return payment.Execute(apiContext, paymentExecution);
        }

        public ActionResult PaymentWithPaypal(Account account)
        {
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Product/PaymentWithPaypal?";
                    var guid = Convert.ToString((new Random()).Next(100000));
                    var createPayment = CreatePayment(apiContext, baseURI + "guid=" + guid, account);
                    var links = createPayment.links.GetEnumerator();
                    string paypalRedirectUrl = string.Empty;

                    while (links.MoveNext())
                    {
                        Links link = links.Current;
                        if (link.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectUrl = link.href;
                        }
                    }
                    Session.Add(guid, createPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    var guid = Request.Params["guid"];
                    var executePayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    if (executePayment.state.ToLower() != "approved")
                    {
                        return View("Failure");
                    }
                }
            }
            catch (Exception ex)
            {
                PaypalLogger.Log("Error: " + ex.Message);
                return View("Failure");
            }
            //@account.state = 2;
            return View("Success");
        }
    }
}