using JsonRpc.CoreCLR.Client.V8.Interfaces;
using OdooRpc.CoreCLR.Client.V8.Models;

namespace OdooRpc.CoreCLR.Client.V8.Internals.Commands;

internal class OdooCreateCommand : OdooAbstractCommand
{
    public OdooCreateCommand(IJsonRpcClient rpcClient)
        : base(rpcClient)
    {
    }

    public Task<long> Execute<T>(OdooSessionInfo sessionInfo, string model, T newRecord)
    {
        return InvokeRpc<long>(sessionInfo, CreateCreateRequest(sessionInfo, model, newRecord));
    }

    private OdooRpcRequest CreateCreateRequest(OdooSessionInfo sessionInfo, string model, object newRecord)
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
                model,
                "create",
                new object[]
                {
                    newRecord
                }
            },
            context = sessionInfo.UserContext
        };
    }
}