using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurentBankServer
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Bank b = new Bank();

            Employee e1 = new Employee(1, "Raja");
            Employee e2 = new Employee(2, "Raju");



            Account a1 = new Account(100, 2000);
            Account a2 = new Account(101, 20000);
            Account a3 = new Account(102, 200350);
            Account a4 = new Account(103, 20700);
            Account a5 = new Account(103, 20700);
            Account a6 = new Account(103, 20700);


            // employee 1 tries to create c1 account
            Customer c1 = new Customer(1, "ram", a1);
            Customer c2 = new Customer(2, "rama", a2);
            Customer c3 = new Customer(3, "aram", a3);
            Customer c4 = new Customer(4, "aaa", a4);
            Customer c5 = new Customer(5, "bbb", a5);
            Customer c6 = new Customer(6, "ccc", a6);

            List<Customer> listc = new List<Customer>();

            listc.Add(c1);
            listc.Add(c2);
            listc.Add(c3);
            listc.Add(c4);
            listc.Add(c5);
            listc.Add(c6);


            List<Task> lt = new List<Task>();

      // CUSTOMERS WILL BE SERVICED CONCURRENTLY BY BOTH THE EEMPLOYEES

          lt.Add(  await  Task.Factory.StartNew(() => AddByE1(e1, listc)));

          lt.Add(  await Task.Factory.StartNew(() => AddByE2(e2, listc)));


            Task.WaitAll(lt.ToArray());


            // WILL SHOW ACCOUNTS ADDED IN THE CONCURRENT BAG
            Bank.ShowAllAccountsInConcurrentList();

           // WILL SHOW ACCOUNTS ADDED IN THE CONCURRENT DICTIONARY
            Console.WriteLine(" dict ");
            Bank.ShowAllAccountsInConcurrentDict();






            Console.ReadLine();






            /*

                        await Task.Factory.StartNew( async () =>
                       {
                           foreach (var x in listc)
                           {
                               Console.WriteLine(" CUSTOMER ADDED BY E1 ");
                           await e1.AddAccountToBankServer(Bank.acc, x.account);


                           }
                       }


                            );



                        await Task.Factory.StartNew(async() =>
                        {
                            foreach (var x in listc)
                            {
                                Console.WriteLine(" CUSTOMER ADDED BY E2 ");
                                await e2.AddAccountToBankServer(Bank.acc, x.account);


                            }
                        }


                           );








                        /*
                                    foreach(var x in listc)
                                    {
                                        Console.WriteLine(" CUSTOMER ADDED BY E1 ");
                                      await  e1.AddAccountToBankServer(Bank.acc, x.account);


                                    }


                                    foreach(var y in listc)
                                    {
                                        Console.WriteLine(" CUSTOMER ADDED BY E2 ");
                                        await e2.AddAccountToBankServer(Bank.acc, y.account);

                                    }

                */










            // add accounts to the servet concurrently such 
            // that the work is shared between the Employees














        }




        public static async Task AddByE1(Employee e1,List<Customer> listc)
        {
            foreach (var x in listc)
            {
                if (!Bank.acc.Contains(x.account))
                {
                    Console.WriteLine(" CUSTOMER ADDED BY E1 ");
                    await e1.AddAccountToBankServer(Bank.acc,Bank.dict, x.account);
                }

            }


        }

        public static async Task AddByE2(Employee e2, List<Customer> listc)
        {
            foreach (var x in listc)
            {
                if (!Bank.acc.Contains(x.account))
                {
                    Console.WriteLine(" CUSTOMER ADDED BY E2 ");
                    await e2.AddAccountToBankServer(Bank.acc,Bank.dict, x.account);
                }

            }


        }











    }
}
