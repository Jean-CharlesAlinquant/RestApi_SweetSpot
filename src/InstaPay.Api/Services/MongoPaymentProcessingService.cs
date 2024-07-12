using InstaPay.Api.Controllers.Dtos;
using InstaPay.Api.Domain.Interfaces;
using InstaPay.Api.Domain.Models;

namespace InstaPay.Api.Services;

public class MongoPaymentProcessingService : IPaymentProcessingService
{
    private readonly IRepository<SepaMessage> _repository;

    public MongoPaymentProcessingService(IRepository<SepaMessage> repository)
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
            Console.WriteLine(sepaMessage);
            return response;
        }

        throw new ArgumentException("Invalid data for PACS.002");
    }

    public async Task<CreditResponseDto> ProcessPacs008Async(SepaInboundMessageDto request)
    {
        if (request.Data is Pacs008DataDto pacs008DataField)
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

            var transactionId = request.CorrelationKey;
            var sepaMessage = new SepaMessage
            {
                TransactionId = transactionId!,
                Header = new SepaHeader
                {
                    Version = request.Version,
                    ApplicationId = request.ApplicationId,
                    LocalAddressType = request.LocalAddress,
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
                Data = new Sepa008Data
                {
                    LclInstrm = pacs008DataField.LclInstrm,
                    TransactionId = pacs008DataField.TransactionId,
                    SttlmntDate = pacs008DataField.SttlmntDate,
                    SCTInstTimestamp = pacs008DataField.SCTInstTimestamp,
                    Order = new SepaOrder
                    {
                        OriginatorName = pacs008DataField.OrderField.OriginatorName,
                        OriginatorLEI = pacs008DataField.OrderField?.OriginatorLEI,
                        OriginatorAccountProxy = pacs008DataField.OrderField?.OriginatorAccountProxy,
                        OriginatorIban = pacs008DataField.OrderField!.OriginatorIban,
                        OriginatorCountry = pacs008DataField.OrderField?.OriginatorCountry,
                        PostalAddress = new SepaAddress
                        {
                            Department = pacs008DataField.OrderField?.OriginatorPostalAddress?.Department,
                            SubDepartment = pacs008DataField.OrderField?.OriginatorPostalAddress?.SubDepartment,
                            StreetName = pacs008DataField.OrderField?.OriginatorPostalAddress?.StreetName,
                            BuildingNumber = pacs008DataField.OrderField?.OriginatorPostalAddress?.BuildingNumber,
                            BuildingName = pacs008DataField.OrderField?.OriginatorPostalAddress?.BuildingName,
                            Floor = pacs008DataField.OrderField?.OriginatorPostalAddress?.Floor,
                            PostBox = pacs008DataField.OrderField?.OriginatorPostalAddress?.PostBox,
                            Room = pacs008DataField.OrderField?.OriginatorPostalAddress?.Room,
                            PostCode = pacs008DataField.OrderField?.OriginatorPostalAddress?.PostCode,
                            TownName = pacs008DataField.OrderField?.OriginatorPostalAddress?.TownName,
                            TownLocationName = pacs008DataField.OrderField?.OriginatorPostalAddress?.TownLocationName,
                            DistrictName = pacs008DataField.OrderField?.OriginatorPostalAddress?.DistrictName,
                            CountrySubDivision = pacs008DataField.OrderField?.OriginatorPostalAddress?.CountrySubDivision
                        },
                        OriginatorAddress = pacs008DataField.OrderField?.OriginatorAddress,
                        OriginatorPrvId = pacs008DataField.OrderField?.OriginatorPrvId,
                        OriginatorUltimateName = pacs008DataField.OrderField?.OriginatorUltimateName,
                        OriginatorUltimateId = pacs008DataField.OrderField?.OriginatorUltimateId
                    },
                    Beneficiary = new SepaBeneficiary
                    {
                        BeneficiaryName = pacs008DataField.BeneficiaryField.BeneficiaryName,
                        BeneficiaryLEI = pacs008DataField.BeneficiaryField?.BeneficiaryLEI,
                        BeneficiaryAccountProxy = pacs008DataField.BeneficiaryField?.BeneficiaryAccountProxy,
                        BeneficiaryIban = pacs008DataField.BeneficiaryField!.BeneficiaryIban,
                        BeneficiaryBic = pacs008DataField.BeneficiaryField.BeneficiaryBic,
                        PostalAddress = new SepaAddress
                        {
                            Department = pacs008DataField.BeneficiaryField.BeneficiaryPostalAddress?.Department,
                            SubDepartment = pacs008DataField.BeneficiaryField.BeneficiaryPostalAddress?.SubDepartment,
                            StreetName = pacs008DataField.BeneficiaryField.BeneficiaryPostalAddress?.StreetName,
                            BuildingNumber = pacs008DataField.BeneficiaryField.BeneficiaryPostalAddress?.BuildingNumber,
                            BuildingName = pacs008DataField.BeneficiaryField.BeneficiaryPostalAddress?.BuildingName,
                            Floor = pacs008DataField.BeneficiaryField.BeneficiaryPostalAddress?.Floor,
                            PostBox = pacs008DataField.BeneficiaryField.BeneficiaryPostalAddress?.PostBox,
                            Room = pacs008DataField.BeneficiaryField.BeneficiaryPostalAddress?.Room,
                            PostCode = pacs008DataField.BeneficiaryField.BeneficiaryPostalAddress?.PostCode,
                            TownName = pacs008DataField.BeneficiaryField.BeneficiaryPostalAddress?.TownName,
                            TownLocationName = pacs008DataField.BeneficiaryField.BeneficiaryPostalAddress?.TownLocationName,
                            DistrictName = pacs008DataField.BeneficiaryField.BeneficiaryPostalAddress?.DistrictName,
                            CountrySubDivision = pacs008DataField.BeneficiaryField.BeneficiaryPostalAddress?.CountrySubDivision
                        },
                        BeneficiaryAddress = pacs008DataField.BeneficiaryField?.BeneficiaryAddress,
                        BeneficiaryCountry = pacs008DataField.BeneficiaryField?.BeneficiaryCountry,
                        BeneficiaryBankName = pacs008DataField.BeneficiaryField?.BeneficiaryBankName,
                        BeneficiaryPrvId = pacs008DataField.BeneficiaryField?.BeneficiaryPrvId,
                        BeneficiaryUltimateName = pacs008DataField.BeneficiaryField?.BeneficiaryUltimateName,
                        BeneficiaryUltimateLEI = pacs008DataField.BeneficiaryField?.BeneficiaryUltimateLEI,
                        BeneficiaryUltimateId = pacs008DataField.BeneficiaryField?.BeneficiaryUltimateId
                    },
                    PaymentDetails = new SepaPaymentDetails
                    {
                        Amount = pacs008DataField.PaymentDetails.Amount,
                        Currency = pacs008DataField.PaymentDetails.Currency,
                        CtgyPurpCode = pacs008DataField.PaymentDetails?.CtgyPurpCode,
                        CtgyPurpValue = pacs008DataField.PaymentDetails?.CtgyPurpValue,
                        Uri = pacs008DataField.PaymentDetails!.Uri,
                        RemittanceInfo = pacs008DataField.PaymentDetails?.RemittanceInfo,
                        RemittanceInfoStrd_CdtrRefInfCd = pacs008DataField.PaymentDetails?.RemittanceInfoStrd_CdtrRefInfCd,
                        RemittanceInfoStrd_CdtrRefInfIssr = pacs008DataField.PaymentDetails?.RemittanceInfoStrd_CdtrRefInfIssr,
                        RemittanceInfoStrd_CdtrRefInfRef = pacs008DataField.PaymentDetails?.RemittanceInfoStrd_CdtrRefInfRef
                    },
                    Pacs008 = new SepaPacs008
                    {
                        MessaggioPacs008 = pacs008DataField.Pacs008.MessaggioPacs008,
                    }
                },
                CreateTimestamp = DateTime.Now,
            };

            await _repository.SaveAsync(sepaMessage);

            return response;
        }

        throw new ArgumentException("Invalid data for PACS.008");
    }
}