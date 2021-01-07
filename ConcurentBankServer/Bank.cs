using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurentBankServer
{
    class Bank
    {
        List<Employee> emp;
        List<Customer> cus;
       public  static ConcurrentBag<Account> acc;
        public static ConcurrentDictionary<int,Account> dict;


        public Bank()
        {
            emp = new List<Employee>();
            cus = new List<Customer>();
            acc = new ConcurrentBag<Account>();
            dict = new ConcurrentDictionary<int, Account>();

        }

       static public void ShowAllAccountsInConcurrentList()
        {
            foreach(var x in acc)
            {
                Console.WriteLine( x.accountnumber + " " + x.balance );
            }

        }


        static public void ShowAllAccountsInConcurrentDict()
        {
            foreach (var x in dict)
            {
                Console.WriteLine(x.Key + " " + x.Value.balance);
            }

        }




    }
}
