using System.Net.Http.Json;
using Shared;

namespace ClientLibrary;

public class CrudApiClient : ICrudApiClient
{
    protected readonly HttpClient _httpClient;
    protected readonly string _baseRoute;

    public CrudApiClient(HttpClient httpClient, string baseRoute = "api/someentity")
    {
        _httpClient = httpClient;
        _baseRoute = baseRoute;
    }

    public async Task<SomeEntity> CreateAsync(SomeEntity entity)
    {
        var response = await _httpClient.PostAsJsonAsync(_baseRoute, entity);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<SomeEntity>() ?? throw new Exception("Error");
    }

    public async Task<SomeEntity> UpdateAsync(SomeEntity entity)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_baseRoute}/{entity.Id}", entity);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<SomeEntity>() ?? throw new Exception("Error");
    }

    public async Task<SomeEntity> GetOneAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<SomeEntity>($"{_baseRoute}/{id}") ?? throw new Exception("Error");
    }

    public async Task<List<SomeEntity>> GetManyAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<SomeEntity>>(_baseRoute) ?? new List<SomeEntity>();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseRoute}/{id}");
        response.EnsureSuccessStatusCode();
    }
}