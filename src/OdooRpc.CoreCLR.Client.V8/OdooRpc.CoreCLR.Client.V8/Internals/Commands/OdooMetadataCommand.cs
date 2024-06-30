using JsonRpc.CoreCLR.Client.V8.Interfaces;
using OdooRpc.CoreCLR.Client.V8.Models;
using OdooRpc.CoreCLR.Client.V8.Models.Parameters;

namespace OdooRpc.CoreCLR.Client.V8.Internals.Commands;

internal class OdooMetadataCommand : OdooAbstractCommand
{
    public OdooMetadataCommand(IJsonRpcClient rpcClient)
        : base(rpcClient)
    {
    }

    public Task<IEnumerable<OdooMetadata>> Execute(OdooSessionInfo sessionInfo, OdooMetadataParameters matadataParams)
    {
        return InvokeRpc<IEnumerable<OdooMetadata>>(sessionInfo, CreateMetadataRequest(sessionInfo, matadataParams));
    }

    private OdooRpcRequest CreateMetadataRequest(OdooSessionInfo sessionInfo, OdooMetadataParameters matadataParams)
    {
        List<object> requestArgs = new List<object>(
            new object[]
            {
                sessionInfo.Database,
                sessionInfo.UserId,
                sessionInfo.Password,
                matadataParams.Model,
                "get_metadata",
                new object[]
                {
                    matadataParams.Ids
                }
            }
        );

        return new OdooRpcRequest()
        {
            service = "object",
            method = "execute_kw",
            args = requestArgs.ToArray(),
            context = new OdooUserContext()
        };
    }
}