using InstaPay.Api.Controllers.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace InstaPay.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentsController() : ControllerBase
{
    [HttpPost]
    public IActionResult ProcessSepaMessage([FromBody] SepaInboundMsg request)
    {
        if (request == null)
        {
            return BadRequest("Request body is null");
        }

        if (string.IsNullOrEmpty(request.MessageType))
        {
            return BadRequest("MessageType is required");
        }

        switch (request.MessageType)
        {
            case "PACS.002":
                if (request.Data is Pacs002DataField)
                {
                    var response = new CreditResponse
                    {
                        CreationTimestamp = request.CreationTimestamp.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        CorrelationKey = request.CorrelationKey,
                        MessageType = request.MessageType,
                        ACH = request.ACH,
                        ReturnCode = request.ReturnCode,
                        PaymentStatus = request.ReturnCode == "00000000" ? "ACCEPTED" : "REJECTED",
                        Data = request.Data
                    };

                    return Ok(response);
                }

                return BadRequest("Invalid data for PACS.002");

            case "PACS.008":
                if (request.Data is Pacs008DataField)
                {
                    var response = new CreditResponse
                    {
                        CreationTimestamp = request.CreationTimestamp.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        CorrelationKey = request.CorrelationKey,
                        MessageType = request.MessageType,
                        ACH = request.ACH,
                        ReturnCode = request.ReturnCode,
                        PaymentStatus = request.ReturnCode == "00000000" ? "ACCEPTED" : "REJECTED",
                        Data = request.Data
                    };

                    return Ok(response);
                }

                return BadRequest("Invalid data for PACS.008");

            default:
                return Problem("Unsupported MessageType");
        }
    }
}