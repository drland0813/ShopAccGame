using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopAccGame.Models.MyData;
namespace ShopAccGame.Models.DataRequester
{
    public class AccountDAO
    {
        MyDatabase database;

        public AccountDAO()
        {
            database = new MyDatabase();
        }
        public ICollection<Account> getListAccounts ()
        {
            ICollection<Account> data = database.Accounts.Where(a => a.state == 1).ToList();
            return data;
        }
    }
}