using Refit;

namespace Stockino3.Services;

public interface IOpenFigiApi
{
    [Post("/v3/mapping")]
    Task<List<FigiMappingResultContainer>> MapAsync([Body] List<FigiJob> jobs);
}
