using System.Text.Json.Serialization;

namespace OdooRpc.CoreCLR.Client.V8.Models;

public class OdooVersionInfo
{
    [JsonPropertyName("server_version")]
    public string ServerVersion { get; internal set; }

    [JsonPropertyName("server_version_info")]
    public dynamic ServiceVersionInfo { get; internal set; }

    [JsonPropertyName("server_serie")]
    public string ServerSerie { get; internal set; }

    [JsonPropertyName("protocol_version")]
    public long ProtocolVersion { get; internal set; }
}