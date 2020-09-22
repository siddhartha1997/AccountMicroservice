using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountType { get; set; }
        public int Balance { get; set; }
    }
}
