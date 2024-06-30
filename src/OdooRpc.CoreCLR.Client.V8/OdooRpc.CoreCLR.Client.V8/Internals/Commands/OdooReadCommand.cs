﻿using JsonRpc.CoreCLR.Client.V8.Interfaces;
using OdooRpc.CoreCLR.Client.V8.Models;
using OdooRpc.CoreCLR.Client.V8.Models.Parameters;
using System.Dynamic;

namespace OdooRpc.CoreCLR.Client.V8.Internals.Commands;

internal class OdooReadCommand : OdooAbstractCommand
{
    public OdooReadCommand(IJsonRpcClient rpcClient)
        : base(rpcClient)
    {
    }

    public Task<T> Execute<T>(OdooSessionInfo sessionInfo, OdooGetParameters getParams, OdooFieldParameters fieldParams)
    {
        return InvokeRpc<T>(sessionInfo, CreateReadRequest(sessionInfo, getParams, fieldParams));
    }

    private OdooRpcRequest CreateReadRequest(OdooSessionInfo sessionInfo, OdooGetParameters getParams, OdooFieldParameters fieldParams)
    {
        List<object> requestArgs = new List<object>(
            new object[]
            {
                sessionInfo.Database,
                sessionInfo.UserId,
                sessionInfo.Password,
                getParams.Model,
                "read",
                new object[]
                {
                    getParams.Ids
                }
            }
        );

        if (fieldParams != null && fieldParams.Count > 0)
        {
            dynamic getOptions = new ExpandoObject();
            getOptions.fields = fieldParams.ToArray();
            requestArgs.Add(getOptions);
        }

        return new OdooRpcRequest()
        {
            service = "object",
            method = "execute_kw",
            args = requestArgs.ToArray(),
            context = sessionInfo.UserContext
        };
    }
}