using Domain;

namespace Infrastucture
{
    public class SmsMessageService : IMessageService
    {
        public void Send(string content)
        {
            System.Console.WriteLine($"Send {content} via sms");
        }
    }
}
