using System.Net.Http.Json;
using Shared;

namespace ClientLibrary;

public class ImageApiClient : IImageApiClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseRoute = "api/someimageentity";

    public ImageApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<SomeImageEntity> GetImageAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<SomeImageEntity>($"{_baseRoute}/{id}") ?? throw new Exception("Failed to deserialize");
    }

    public async Task<SomeImageEntity> SetImageAsync(SomeImageEntity entity)
    {
        var response = await _httpClient.PostAsJsonAsync(_baseRoute, entity);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<SomeImageEntity>() ?? throw new Exception("Failed to deserialize");
    }

    public async Task<List<SomeImageEntity>> GetEntitiesByFilterAsync(FilterModel filter)
    {
        var queryParams = BuildQueryString(filter);
        var url = $"{_baseRoute}/filter{queryParams}";
        return await _httpClient.GetFromJsonAsync<List<SomeImageEntity>>(url) ?? new List<SomeImageEntity>();
    }

    private string BuildQueryString(FilterModel filter)
    {
        var parameters = new List<string>();
        
        if (!string.IsNullOrEmpty(filter.Name))
            parameters.Add($"name={Uri.EscapeDataString(filter.Name)}");
        if (!string.IsNullOrEmpty(filter.Status))
            parameters.Add($"status={Uri.EscapeDataString(filter.Status)}");

        return parameters.Any() ? $"?{string.Join("&", parameters)}" : "";
    }
}