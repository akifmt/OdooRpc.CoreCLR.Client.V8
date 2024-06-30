namespace OdooRpc.CoreCLR.Client.V8.Models.Parameters;

public class OdooMetadataParameters : OdooGetParameters
{
    public OdooMetadataParameters(string model)
        : base(model, new List<long>())
    {
    }

    public OdooMetadataParameters(string model, IEnumerable<long> ids)
        : base(model, ids)
    {
    }
}