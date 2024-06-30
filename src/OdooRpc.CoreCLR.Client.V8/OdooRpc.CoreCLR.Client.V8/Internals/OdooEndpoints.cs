using OdooRpc.CoreCLR.Client.V8.Models;

namespace OdooRpc.CoreCLR.Client.V8.Internals;

internal static class OdooEndpoints
{
    public static Uri GetJsonRpcUri(OdooConnectionInfo connectionInfo)
    {
        return GetEndpointUri(connectionInfo, "/jsonrpc");
    }

    private static Uri GetEndpointUri(OdooConnectionInfo connectionInfo, string endpoint)
    {
        return new Uri(string.Format("{0}://{1}:{2}{3}",
            GetConnectionProtocol(connectionInfo),
            connectionInfo.Host,
            connectionInfo.Port,
            endpoint
        ));
    }

    private static string GetConnectionProtocol(OdooConnectionInfo connectionInfo)
    {
        return connectionInfo.IsSSL ? "https" : "http";
    }
}