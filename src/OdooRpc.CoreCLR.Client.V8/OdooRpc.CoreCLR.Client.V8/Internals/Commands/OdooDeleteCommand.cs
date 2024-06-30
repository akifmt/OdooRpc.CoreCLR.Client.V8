using JsonRpc.CoreCLR.Client.V8.Interfaces;
using OdooRpc.CoreCLR.Client.V8.Models;
using OdooRpc.CoreCLR.Client.V8.Models.Parameters;

namespace OdooRpc.CoreCLR.Client.V8.Internals.Commands;

internal class OdooDeleteCommand : OdooAbstractCommand
{
    public OdooDeleteCommand(IJsonRpcClient rpcClient)
        : base(rpcClient)
    {
    }

    public Task Execute(OdooSessionInfo sessionInfo, OdooDeleteParameters parameters)
    {
        return InvokeRpc<object>(sessionInfo, CreateDeleteRequest(sessionInfo, parameters));
    }

    private OdooRpcRequest CreateDeleteRequest(OdooSessionInfo sessionInfo, OdooDeleteParameters parameters)
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
                "unlink",
                new object[]
                {
                    parameters.Ids.ToArray()
                }
            },
            context = sessionInfo.UserContext
        };
    }
}