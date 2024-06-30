using JsonRpc.CoreCLR.Client.V8.Interfaces;
using OdooRpc.CoreCLR.Client.V8.Models;
using OdooRpc.CoreCLR.Client.V8.Models.Parameters;

namespace OdooRpc.CoreCLR.Client.V8.Internals.Commands;

internal class OdooUpdateCommand : OdooAbstractCommand
{
    public OdooUpdateCommand(IJsonRpcClient rpcClient)
        : base(rpcClient)
    {
    }

    public Task Execute<T>(OdooSessionInfo sessionInfo, OdooUpdateParameters<T> parameters)
    {
        return InvokeRpc<object>(sessionInfo, CreateUpdateRequest(sessionInfo, parameters));
    }

    private OdooRpcRequest CreateUpdateRequest<T>(OdooSessionInfo sessionInfo, OdooUpdateParameters<T> parameters)
    {
        return new OdooRpcRequest()
        {
            service = "object",
            method = "execute_kw",
            args = new object[]
            {
                sessionInfo.Database,
                sessionInfo.UserId,
                sessionInfo.Password,
                parameters.Model,
                "write",
                new object[]
                {
                    parameters.Ids.ToArray(),
                    parameters.UpdateValues
                }
            },
            context = sessionInfo.UserContext
        };
    }
}