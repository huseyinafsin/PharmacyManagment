using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerRepository());

            foreach (var customer in customerManager.GetCustomersWithDetails().Data)
            {
                Console.WriteLine("Customer Name:"+customer.CustomerName +"\n City:" + customer.Address.City);
            }
        }
    }
}
