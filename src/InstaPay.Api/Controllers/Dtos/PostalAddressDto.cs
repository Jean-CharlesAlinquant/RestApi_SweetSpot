using System.ComponentModel.DataAnnotations;

namespace InstaPay.Api.Controllers.Dtos;

public record PostalAddressDto
{
    [StringLength(70)]
    public string? Department { get; init; }

    [StringLength(70)]
    public string? SubDepartment { get; init; }

    [StringLength(70)]
    public string? StreetName { get; init; }

    [StringLength(16)]
    public string? BuildingNumber { get; init; }

    [StringLength(35)]
    public string? BuildingName { get; init; }

    [StringLength(70)]
    public string? Floor { get; init; }

    [StringLength(16)]
    public string? PostBox { get; init; }

    [StringLength(70)]
    public string? Room { get; init; }

    [StringLength(16)]
    public string? PostCode { get; init; }

    [StringLength(35)]
    public string? TownName { get; init; }

    [StringLength(35)]
    public string? TownLocationName { get; init; }

    [StringLength(35)]
    public string? DistrictName { get; init; }

    [StringLength(35)]
    public string? CountrySubDivision { get; init; }
}