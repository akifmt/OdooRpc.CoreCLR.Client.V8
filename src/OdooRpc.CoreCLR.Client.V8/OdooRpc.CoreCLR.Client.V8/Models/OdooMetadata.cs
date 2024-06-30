using System.Text.Json.Serialization;

namespace OdooRpc.CoreCLR.Client.V8.Models;

public class OdooMetadata
{
    [JsonPropertyName("id")]
    public int Id { get; internal set; }

    [JsonPropertyName("xmlid")]
    public string ExternalId { get; internal set; }

    [JsonPropertyName("create_date")]
    public DateTime CreateDate { get; internal set; }

    [JsonPropertyName("write_date")]
    public DateTime WriteDate { get; internal set; }

    [JsonPropertyName("noupdate")]
    public bool NoUpdate { get; internal set; }

    [JsonPropertyName("create_uid")]
    public dynamic CreateUid { get; internal set; }

    [JsonPropertyName("write_uid")]
    public dynamic WriteUid { get; internal set; }
}