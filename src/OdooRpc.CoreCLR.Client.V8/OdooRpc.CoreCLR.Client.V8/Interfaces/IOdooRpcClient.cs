using OdooRpc.CoreCLR.Client.V8.Models;
using OdooRpc.CoreCLR.Client.V8.Models.Parameters;

namespace OdooRpc.CoreCLR.Client.V8.Interfaces;

public interface IOdooRpcClient
{
    OdooSessionInfo SessionInfo { get; }

    Task<OdooVersionInfo> GetOdooVersion();

    Task Authenticate();

    void SetUserId(long userId);

    Task<Dictionary<string, T>> GetModelFields<T>(OdooGetModelFieldsParameters parameters);

    Task<T> Get<T>(string model, long id);

    Task<T> Get<T>(OdooGetParameters getParameters);

    Task<T> Get<T>(OdooGetParameters getParameters, OdooFieldParameters fieldParameters);

    Task<T> Get<T>(OdooSearchParameters parameters);

    Task<T> Get<T>(OdooSearchParameters parameters, OdooFieldParameters fieldParameters);

    Task<T> Get<T>(OdooSearchParameters searchParameters, OdooPaginationParameters pagParameters);

    Task<T> Get<T>(OdooSearchParameters searchParameters, OdooFieldParameters fieldParameters, OdooPaginationParameters pagParameters);

    Task<IEnumerable<OdooMetadata>> GetMetadata(OdooMetadataParameters parameters);

    Task<T> GetAll<T>(string model, OdooFieldParameters fieldParameters);

    Task<T> GetAll<T>(string model, OdooFieldParameters fieldParameters, OdooPaginationParameters pagParameters);

    Task<T> Search<T>(OdooSearchParameters parameters);

    Task<T> Search<T>(OdooSearchParameters searchParameters, OdooPaginationParameters pagParameters);

    Task<long> SearchCount(OdooSearchParameters parameters);

    Task<long> Create<T>(string model, T newRecord);

    Task Delete(string model, long id);

    Task Delete(OdooDeleteParameters parameters);

    Task Update<T>(string model, long id, T updateValues);

    Task Update<T>(OdooUpdateParameters<T> parameters);
}