using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
   public class CustomerAccount
    {
        decimal balance;

        public void StartupBalance()
        {
            balance = 0;
        }

        public void AddFunds(decimal addToAccount)
        {
            balance += addToAccount;
        }



        public decimal AccountBalance()
        {
            return balance;
        }

    }
}
