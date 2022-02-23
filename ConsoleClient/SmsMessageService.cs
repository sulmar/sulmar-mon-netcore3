using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class SmsMessageService
    {
        public void Send(string content)
        {
            Console.WriteLine($"Sending {content}...");

            Thread.Sleep(TimeSpan.FromSeconds(3));

            Console.WriteLine($"Sent. {content}");
        }

        public decimal Calculate(string content)
        {
            Console.WriteLine($"Calculating {content}...");

            Thread.Sleep(TimeSpan.FromSeconds(3));

            decimal price = content.Length * 0.99m;

            Console.WriteLine($"Calculated. {price}");

            return price;
        }

        public Task SendAsync(string content)
        {
            return Task.Run(() => Send(content));
        }

        public Task<decimal> CalculateAsync(string content)
        {
            return Task.Run(() => Calculate(content));
        }

    }

    


}
