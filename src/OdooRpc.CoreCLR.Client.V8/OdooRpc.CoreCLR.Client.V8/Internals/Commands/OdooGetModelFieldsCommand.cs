using JsonRpc.CoreCLR.Client.V8.Interfaces;
using OdooRpc.CoreCLR.Client.V8.Models;
using OdooRpc.CoreCLR.Client.V8.Models.Parameters;
using System.Dynamic;

namespace OdooRpc.CoreCLR.Client.V8.Internals.Commands;

internal class OdooGetModelFieldsCommand : OdooAbstractCommand
{
    public OdooGetModelFieldsCommand(IJsonRpcClient rpcClient)
        : base(rpcClient)
    {
    }

    public Task<Dictionary<string, T>> Execute<T>(OdooSessionInfo sessionInfo, OdooGetModelFieldsParameters parameters)
    {
        return InvokeRpc<Dictionary<string, T>>(sessionInfo, CreateGetRequest(sessionInfo, parameters));
    }

    private OdooRpcRequest CreateGetRequest(OdooSessionInfo sessionInfo, OdooGetModelFieldsParameters parameters)
    {
        List<object> requestArgs = new List<object>(
            new object[]
            {
                sessionInfo.Database,
                sessionInfo.UserId,
                sessionInfo.Password,
                parameters.Model,
                "fields_get",
                new object[0]
            }
        );

        dynamic fieldOptions = new ExpandoObject();
        if (parameters.Attributes != null && parameters.Attributes.Count > 0)
        {
            fieldOptions.attributes = parameters.Attributes.ToArray();
        }
        else
        {
            fieldOptions.attributes = new string[] { "string", "help", "type" };
        }
        requestArgs.Add(fieldOptions);

        return new OdooRpcRequest()
        {
            service = "object",
            method = "execute_kw",
            args = requestArgs.ToArray(),
            context = sessionInfo.UserContext
        };
    }
}