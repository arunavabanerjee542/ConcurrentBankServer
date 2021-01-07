using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurentBankServer
{
    class Employee: Person
    {

        public Employee(int i, string n)
        {
            id = i;
            name = n;
            
        }


        public void withdrawmoney()
        {

        }

        public void depositmoney()
        {

        }

        public async Task AddAccountToBankServer(ConcurrentBag<Account> l,ConcurrentDictionary<int,Account> d, Account ac)
        {

           // l.Add(ac);
            d.TryAdd(ac.accountnumber, ac);

           await  Task.Delay(2000);
        }

        public async Task RemoveAccountFromBankSever(ConcurrentBag<Account> l, Account ac)
        {
            if(l.Contains(ac))
                {
              //  l.a;
            }
            await Task.Delay(2000);
        }








    }
}
