using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public List<Customer> customers = null;
        public List<Account> accounts = null;
        int id = 1;
        [HttpPost]
        [Route("createAccount")]
        public string createAccount([FromBody] int id)
        {
            customers = new List<Customer> { new Customer { CustomerId = id, CAccountId = id, SAccountId = id + 1 } };
            accounts = new List<Account> 
            { 
                new Account { AccountId=id,AccountType="Current Account",Balance=0},
                new Account { AccountId=id+1,AccountType="Savings Account",Balance=0}
            };
            return "Current Account Id:" + id.ToString() + "\n" + "Savings Account Id:" + (id + 1).ToString();
        }
        [HttpGet]
        [Route("getCustomerAccounts")]
        public string getCustomerAccounts([FromBody] int id)
        {
            var account = customers.Find(c => c.CustomerId == id);
            var cbal = accounts.Find(a => a.AccountId == account.CAccountId);
            var sbal = accounts.Find(a => a.AccountId == account.SAccountId);
            return "Current Account Id:" + cbal.AccountId + "Current Balance Amount:" + cbal.Balance+"\n"+ "Savings Account Id:" + sbal.AccountId + "Saving Balance Amount:" + sbal.Balance;
        }
        [HttpGet]
        [Route("getAccount")]
        public string getAccount([FromBody] int id)
        {
            var bal = accounts.Find(a => a.AccountId == id);
            return "AccountId:" + id + "Balance:" + bal.Balance;
        }

    }
}
