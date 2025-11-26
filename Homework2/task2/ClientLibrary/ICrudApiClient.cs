using Shared;

namespace ClientLibrary;

public interface ICrudApiClient
{
    Task<SomeEntity> CreateAsync(SomeEntity entity);
    Task<SomeEntity> UpdateAsync(SomeEntity entity);
    Task<SomeEntity> GetOneAsync(int id);
    Task<List<SomeEntity>> GetManyAsync();
    Task DeleteAsync(int id);
}