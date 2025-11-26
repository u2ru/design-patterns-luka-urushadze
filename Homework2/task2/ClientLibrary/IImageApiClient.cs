using Shared;

namespace ClientLibrary;

public interface IImageApiClient
{
    Task<SomeImageEntity> GetImageAsync(int id);
    Task<SomeImageEntity> SetImageAsync(SomeImageEntity entity);
    Task<List<SomeImageEntity>> GetEntitiesByFilterAsync(FilterModel filter);
}