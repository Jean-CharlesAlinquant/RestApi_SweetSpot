using InstaPay.Api.Controllers.Dtos;

namespace InstaPay.Api.Domain.Models;

public class SepaFullPacs008
{
    required public SepaHeader SepaHeader { get; init; }
    required public Pacs008DataDto Sepa008Data { get; init; }
}