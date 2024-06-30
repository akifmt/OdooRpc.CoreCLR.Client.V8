using JsonRpc.CoreCLR.Client.V8.Interfaces;

namespace OdooRpc.CoreCLR.Client.V8.Internals.Interfaces;

internal interface IJsonRpcClientFactory
{
    IJsonRpcClient GetRpcClient(Uri rpcEndpoint);
}