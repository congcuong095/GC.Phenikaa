using Application.MessageInterface;
using Application.UnitOfWork;
using Domain.Entities;

namespace Infrastructure.Message.Zalo.SendMessage;

public class SendZalo : IMessageZalo
{
    private readonly IUnitOfWork _unitOfWork;

    public SendZalo(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async void GetToken()
    {
        Console.WriteLine("Receive token");
        await _unitOfWork.ZaloTokenRepository.Create(new ZaloToken());
    }

    public void SendMessage(string message)
    {
        GetToken();
        Console.WriteLine($"Send message via Zalo: {message}");
    }
}
