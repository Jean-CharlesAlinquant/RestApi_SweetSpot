using InstaPay.Api.Controllers.Dtos;

namespace InstaPay.Api.Domain.Interfaces;

public interface IPaymentProcessingService
{
    Task<CreditResponseDto> ProcessPacs002Async(SepaInboundMessageDto request);
    Task<CreditResponseDto> ProcessPacs008Async(SepaInboundMessageDto request);
}