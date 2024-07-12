using System.Text.Json;

using InstaPay.Api.Controllers.Dtos;
using InstaPay.Api.Domain.Interfaces;
using InstaPay.Api.Domain.Models;

namespace InstaPay.Api.Services;

public class SqlPaymentProcessingService : IPaymentProcessingService
{
    private readonly IRepository<SepaBlob> _repository;

    public SqlPaymentProcessingService(IRepository<SepaBlob> repository)
    {
        _repository = repository;
    }

    public async Task<CreditResponseDto> ProcessPacs002Async(SepaInboundMessageDto request)
    {
        if (request.Data is Pacs002DataDto)
        {
            var response = new CreditResponseDto
            {
                CreationTimestamp = request.CreationTimestamp.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                CorrelationKey = request.CorrelationKey,
                MessageType = request.MessageType,
                ACH = request.ACH,
                ReturnCode = request.ReturnCode,
                PaymentStatus = request.ReturnCode == "00000000" ? "ACCEPTED" : "REJECTED",
                Data = request.Data
            };

            var transactionId = request.CorrelationKey ?? throw new ArgumentException("CorrelationKey is null");

            var sepaMessage = await _repository.GetByIdAsync(transactionId);
            string jsonContent = sepaMessage!.Content;
            SepaFullPacs008 originaldMsg = JsonSerializer.Deserialize<SepaFullPacs008>(jsonContent)!;
            Console.WriteLine(originaldMsg.SepaHeader.MessageType);
            return response;
        }

        throw new ArgumentException("Invalid data for PACS.002");
    }

    public async Task<CreditResponseDto> ProcessPacs008Async(SepaInboundMessageDto request)
    {
        if (request.Data is Pacs008DataDto field)
        {
            var response = new CreditResponseDto
            {
                CreationTimestamp = request.CreationTimestamp.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                CorrelationKey = request.CorrelationKey,
                MessageType = request.MessageType,
                ACH = request.ACH,
                ReturnCode = request.ReturnCode,
                PaymentStatus = request.ReturnCode == "00000000" ? "ACCEPTED" : "REJECTED",
                Data = request.Data,
            };

            // Construct a new SepaInboundMsg with the casted Data
            var sepaInboundMsgWithConcreteData = new SepaFullPacs008
            {
                SepaHeader = new SepaHeader
                {
                    Version = request.Version,
                    ApplicationId = request.ApplicationId,
                    LocalAddressType = request.LocalAddressType,
                    LocalAddress = request.LocalAddress,
                    RemoteAddressType = request.RemoteAddressType,
                    RemoteAddress = request.RemoteAddress,
                    ACH = request.ACH,
                    SettlementMethod = request.SettlementMethod,
                    Service = request.Service,
                    FormatType = request.FormatType,
                    OperationCode = request.OperationCode,
                    MessageType = request.MessageType,
                    CreationTimestamp = request.CreationTimestamp,
                    CorrelationKey = request.CorrelationKey,
                    Signature = request.Signature,
                },
                Sepa008Data = field // Cast the Data to its concrete type
            };

            var transactionId = request.CorrelationKey;
            var sepaMessage = new SepaBlob
            {
                TransactionId = transactionId!,
                Content = JsonSerializer.Serialize(sepaInboundMsgWithConcreteData),
                CreatedTimestamp = DateTime.Now,
            };

            await _repository.SaveAsync(sepaMessage);

            return response;
        }

        throw new ArgumentException("Invalid data for PACS.008");
    }
}