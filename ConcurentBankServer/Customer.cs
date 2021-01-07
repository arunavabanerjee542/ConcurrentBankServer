using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurentBankServer
{
    class Customer : Person
    {
       
        public Account account;

        public Customer(int i, string n,Account a )
        {
            id = i;
            name = n;
            account = a;
        }

        public void Withdarw()
        {

        }

        public void Deposit()
        {

        }

        public async Task CreateAccount(Account ac,Employee e)
        {
          await  e.AddAccountToBankServer(Bank.acc,Bank.dict, ac);
        }

        public async Task CloseAccount(Account ac,Employee e)
        {
           await  e.RemoveAccountFromBankSever(Bank.acc, ac);
        }

    }
}
