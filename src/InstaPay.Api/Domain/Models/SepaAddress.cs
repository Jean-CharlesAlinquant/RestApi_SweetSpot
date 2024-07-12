namespace InstaPay.Api.Domain.Models;

public class SepaAddress
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

    public override string ToString()
    {
        return $"SepaAddress:\n" +
               $"  Department: {Department ?? "N/A"}\n" +
               $"  SubDepartment: {SubDepartment ?? "N/A"}\n" +
               $"  StreetName: {StreetName ?? "N/A"}\n" +
               $"  BuildingNumber: {BuildingNumber ?? "N/A"}\n" +
               $"  BuildingName: {BuildingName ?? "N/A"}\n" +
               $"  Floor: {Floor ?? "N/A"}\n" +
               $"  PostBox: {PostBox ?? "N/A"}\n" +
               $"  Room: {Room ?? "N/A"}\n" +
               $"  PostCode: {PostCode ?? "N/A"}\n" +
               $"  TownName: {TownName ?? "N/A"}\n" +
               $"  TownLocationName: {TownLocationName ?? "N/A"}\n" +
               $"  DistrictName: {DistrictName ?? "N/A"}\n" +
               $"  CountrySubDivision: {CountrySubDivision ?? "N/A"}";
    }
}