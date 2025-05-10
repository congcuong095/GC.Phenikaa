using Application.MessageInterface;

namespace Infrastructure.Message.SMS.SendMessage;

public class SendSMS : IMessageSMS
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Send message via SMS: {message}");
    }
}
