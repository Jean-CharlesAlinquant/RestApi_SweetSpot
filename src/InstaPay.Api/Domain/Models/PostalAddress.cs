namespace InstaPay.Api.Domain.Models;

public record PostalAddress
{
    public string? Department { get; init; }
    public string? SubDepartment { get; init; }
    public string? StreetName { get; init; }
    public string? BuildingNumber { get; init; }
    public string? BuildingName { get; init; }
    public string? Floor { get; init; }
    public string? PostBox { get; init; }
    public string? Room { get; init; }
    public string? PostCode { get; init; }
    public string? TownName { get; init; }
    public string? TownLocationName { get; init; }
    public string? DistrictName { get; init; }
    public string? CountrySubDivision { get; init; }
}