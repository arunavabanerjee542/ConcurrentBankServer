using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurentBankServer
{
    class Account
    {
        public int accountnumber;
        public int balance;

        public Account(int ac, int b)
        {
            accountnumber = ac;
            balance = b;
        }

    }
}
