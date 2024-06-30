namespace OdooRpc.CoreCLR.Client.V8.Models.Parameters;

public class OdooSearchParameters
{
    public string Model { get; private set; }
    public OdooDomainFilter DomainFilter { get; private set; }

    public OdooSearchParameters(string model)
        : this(model, new OdooDomainFilter())
    {
    }

    public OdooSearchParameters(string model, OdooDomainFilter domainFilter)
    {
        this.Model = model;
        this.DomainFilter = domainFilter;
    }
}