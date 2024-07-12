namespace InstaPay.Api.Domain.Models;

public class SepaPacs008
{
    required public string MessaggioPacs008 { get; init; }
    public override string ToString()
    {
        return $"SepaPacs008:\n" +
               $"  MessaggioPacs008: {MessaggioPacs008}";
    }
}