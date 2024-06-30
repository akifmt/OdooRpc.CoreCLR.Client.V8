using JsonRpc.CoreCLR.Client.V8.Interfaces;
using OdooRpc.CoreCLR.Client.V8.Models;

namespace OdooRpc.CoreCLR.Client.V8.Internals.Commands;

internal class OdooLoginCommand : OdooAbstractCommand
{
    public bool IsLoggedIn { get; private set; }
    public long? UserId { get; private set; }

    public OdooLoginCommand(IJsonRpcClient rpcClient)
        : base(rpcClient, isLoginRequired: false)
    {
    }

    public async Task Execute(OdooSessionInfo sessionInfo)
    {
        this.IsLoggedIn = false;
        this.UserId = null;

        var request = CreateLoginRequest(sessionInfo);
        var result = await InvokeRpc<object>(sessionInfo, request);

        long uid;
        if (long.TryParse(result.ToString(), out uid))
        {
            this.IsLoggedIn = true;
            this.UserId = uid;
        }
    }

    private OdooRpcRequest CreateLoginRequest(OdooSessionInfo sessionInfo)
    {
        return new OdooRpcRequest()
        {
            service = "common",
            method = "authenticate",
            args = new object[]
            {
                sessionInfo.Database,
                sessionInfo.Username,
                sessionInfo.Password,
                sessionInfo.UserContext
            }
        };
    }
}