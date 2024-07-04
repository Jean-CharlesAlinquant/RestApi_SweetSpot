namespace InstaPay.Api.Domain;

public class Payment
{
    public Guid Id { get; set; } = Guid.NewGuid();

    required public string Name { get; set; }

    required public string Category { get; set; }

    required public string SubCategory { get; set; }
}