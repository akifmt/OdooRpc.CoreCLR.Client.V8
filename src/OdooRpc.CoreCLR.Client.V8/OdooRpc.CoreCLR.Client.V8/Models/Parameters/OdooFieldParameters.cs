namespace OdooRpc.CoreCLR.Client.V8.Models.Parameters;

public class OdooFieldParameters : List<string>
{
    public OdooFieldParameters()
        : base()
    {
    }

    public OdooFieldParameters(IEnumerable<string> collection)
        : base(collection)
    {
    }
}