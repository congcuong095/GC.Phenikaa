using Application.DTOs;
using Application.GCUnitOfWork;
using Application.MessageInterface;
using Application.UnitOfWork;
using Domain.Entities;

namespace Application.UseCase;

public class MessageService : IMessageService
{
    private readonly IMessageZalo _messageZalo;
    private readonly IMessageSMS _messageSMS;
    private readonly IGCUnitOfWork _GCUnitOfWork;
    private readonly IUnitOfWork _unitOfWork;

    public MessageService(
        IMessageZalo messageZalo,
        IMessageSMS messageSMS,
        IGCUnitOfWork GCUnitOfWork,
        IUnitOfWork unitOfWork
    )
    {
        _messageSMS = messageSMS;
        _messageZalo = messageZalo;
        _GCUnitOfWork = GCUnitOfWork;
        _unitOfWork = unitOfWork;
    }

    public async Task<SendMessageResponse> SendMessageToCustomer(string message, string customer)
    {
        _messageZalo.SendMessage(message);
        await _unitOfWork.ZaloMessageLogRepository.Create(new ZaloMessageLog());
        _messageSMS.SendMessage(message);
        await _unitOfWork.SMSMessageLogRepository.Create(new SMSMessageLog());

        //Save to GC db
        await _GCUnitOfWork.AgentMessage.UpdateAgentMessage("123", true);

        return new SendMessageResponse { IsSuccess = true };
    }
}
