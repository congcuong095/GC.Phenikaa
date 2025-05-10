using Application.DTOs;

namespace Application.UseCase;

public interface IMessageService
{
    Task<SendMessageResponse> SendMessageToCustomer(string message, string customer);
}
