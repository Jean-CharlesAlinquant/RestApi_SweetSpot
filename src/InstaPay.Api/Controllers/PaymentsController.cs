using InstaPay.Api.Controllers.Dtos;
using InstaPay.Api.Domain.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace InstaPay.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentProcessingService _paymentProcessingService;

    public PaymentsController(IPaymentProcessingService paymentProcessingService)
    {
        _paymentProcessingService = paymentProcessingService;
    }

    [HttpPost]
    public async Task<IActionResult> ProcessSepaMessage([FromBody] SepaInboundMessageDto request)
    {
        if (request == null)
        {
            return BadRequest("Request body is null");
        }

        if (string.IsNullOrEmpty(request.MessageType))
        {
            return BadRequest("MessageType is required");
        }

        try
        {
            CreditResponseDto response;
            switch (request.MessageType)
            {
                case "PACS.002":
                    response = await _paymentProcessingService.ProcessPacs002Async(request);
                    break;

                case "PACS.008":
                    response = await _paymentProcessingService.ProcessPacs008Async(request);
                    break;

                default:
                    return Problem("Unsupported MessageType");
            }

            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}