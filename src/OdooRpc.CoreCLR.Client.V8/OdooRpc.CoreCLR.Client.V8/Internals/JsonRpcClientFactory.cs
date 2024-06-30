using JsonRpc.CoreCLR.Client.V8;
using JsonRpc.CoreCLR.Client.V8.Interfaces;
using OdooRpc.CoreCLR.Client.V8.Internals.Interfaces;

namespace OdooRpc.CoreCLR.Client.V8.Internals;

internal class JsonRpcClientFactory : IJsonRpcClientFactory
{
    public IJsonRpcClient GetRpcClient(Uri rpcEndpoint)
    {
        return new JsonRpcWebClient(rpcEndpoint);
    }
}