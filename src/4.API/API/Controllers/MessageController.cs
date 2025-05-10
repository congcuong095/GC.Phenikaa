using Application.DTOs;
using Application.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/message")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpPost("send-message-to-customer")]
    public async Task<IActionResult> SendMessageToCustomer([FromBody] SendMessageRequest request)
    {
        SendMessageResponse loginResponse = await _messageService.SendMessageToCustomer(
            request.Message,
            request.Customer
        );
        return Ok(loginResponse);
    }
}
