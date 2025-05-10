using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class SendMessageRequest
{
    [Required(ErrorMessage = "Application.DTOs.MESSAGE_IS_REQUIRED")]
    [MaxLength(500, ErrorMessage = "Application.DTOs.MESSAGE_MAX_LENGTH_500")]
    public required string Message { get; set; }

    [Required(ErrorMessage = "Application.DTOs.CUSTOMER_IS_REQUIRED")]
    public required string Customer { get; set; }
}
