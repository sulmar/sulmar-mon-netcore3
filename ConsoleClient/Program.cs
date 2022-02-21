using Domain;
using System;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Customer customer = new Customer();

            var customerInfo = new 
            {
                FirstName = customer.FirstName,
                Salary = customer.Salary
            };

            // customerInfo.Salary = 100m;

            var x = 10;
        }

      
    }

    public class CustomerInfo
    {
        public string FirstName { get; set; }
        public decimal? Salary { get; set; }
    }

    


}
