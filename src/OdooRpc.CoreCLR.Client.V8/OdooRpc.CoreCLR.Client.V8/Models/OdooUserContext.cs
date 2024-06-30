using System.Text.Json.Serialization;

namespace OdooRpc.CoreCLR.Client.V8.Models;

public class OdooUserContext
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Language { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Timezone { get; set; }
}