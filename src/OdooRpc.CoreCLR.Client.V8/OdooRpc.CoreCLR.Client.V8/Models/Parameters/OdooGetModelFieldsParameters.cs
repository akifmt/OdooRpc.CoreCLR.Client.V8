namespace OdooRpc.CoreCLR.Client.V8.Models.Parameters;

public class OdooGetModelFieldsParameters
{
    public string Model { get; private set; }
    public OdooFieldParameters Attributes { get; private set; }

    public OdooGetModelFieldsParameters(string model)
        : this(model, new OdooFieldParameters())
    {
    }

    public OdooGetModelFieldsParameters(string model, OdooFieldParameters attributes)
    {
        this.Model = model;
        this.Attributes = attributes;
    }
}