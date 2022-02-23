using Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleClient
{

    public class DateTimeHelper
    {
        public static bool IsHoliday(DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }
    }

    public static class DateTimeExtensions
    {

        // Metoda rozszerzająca (Extension Method)
        public static bool IsHoliday(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        public static DateTime AddWorkingDays(this DateTime dateTime, int days)
        {
            return dateTime.AddDays(days);
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            DateTimeHelper.IsHoliday(DateTime.Today);

            DateTime.Today.IsHoliday();

            DateTime.Today.AddWorkingDays(10);

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Started!");

            decimal cost = await CalculateAsyncAwaitTest();

            Console.WriteLine(cost);


            

            //  SynchrTest();

            // TaskTest();

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Press any key to continue...");

            Console.ReadKey();

            // AnonymousTest();


        }

        private static async void AsyncAwaitTest()
        {
            SmsMessageService messageService = new SmsMessageService();

            await messageService.SendAsync("Hello World!");

            await messageService.SendAsync("Hello Europe!");

            await messageService.SendAsync("Hello Poland!");
        }

        private static void TaskTest()
        {
            SmsMessageService messageService = new SmsMessageService();

            Task.Run(() => messageService.Send($"{Thread.CurrentThread.ManagedThreadId} Hello World!"))
                .ContinueWith(t => messageService.Send($"{Thread.CurrentThread.ManagedThreadId} Hello Europe!"))
                    .ContinueWith(t => messageService.Send($"{Thread.CurrentThread.ManagedThreadId} Hello Poland!"));
        }

        private static void SendSynchrTest()
        {
            SmsMessageService messageService = new SmsMessageService();

            messageService.Send($"{Thread.CurrentThread.ManagedThreadId} Hello World!");

            messageService.Send($"{Thread.CurrentThread.ManagedThreadId} Hello Europe!");

            messageService.Send($"{Thread.CurrentThread.ManagedThreadId} Hello Poland!");
        }

        private static void CalculateSynchrTest()
        {
            SmsMessageService messageService = new SmsMessageService();

            decimal cost = messageService.Calculate($"Hello World!");
            cost += messageService.Calculate("Hello Europe!");
            cost += messageService.Calculate("Hello Poland!");

            Console.WriteLine(cost);
        }

        private static async Task<decimal> CalculateAsyncAwaitTest()
        {
            SmsMessageService messageService = new SmsMessageService();

            decimal cost = await messageService.CalculateAsync($"Hello World!");
            cost += await messageService.CalculateAsync("Hello Europe!");
            cost += await messageService.CalculateAsync("Hello Poland!");

            return cost;
        }

        private static void AnonymousTest()
        {
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
