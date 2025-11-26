using Shared;

namespace ClientLibrary;

public interface IFlexibleApiClient : ICrudApiClient
{
    Task<List<SomeEntity>> GetByFilterAsync(FilterModel filter);
    Task PrintAsync(int id);
    Task PrintManyAsync(List<int> ids);
    Task SetStatusAsync(int id, string status);
    Task ActivateAsync(int id);
    Task DeactivateAsync(int id);
}