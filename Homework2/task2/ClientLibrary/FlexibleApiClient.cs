using System.Net.Http.Json;
using System.Text;
using Shared;

namespace ClientLibrary;

public class FlexibleApiClient : CrudApiClient, IFlexibleApiClient
{
    public FlexibleApiClient(HttpClient httpClient) : base(httpClient) { }

    public async Task<List<SomeEntity>> GetByFilterAsync(FilterModel filter)
    {
        var queryParams = BuildQueryString(filter);
        var url = $"{_baseRoute}/filter{queryParams}";
        return await _httpClient.GetFromJsonAsync<List<SomeEntity>>(url) ?? new List<SomeEntity>();
    }

    public async Task PrintAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{_baseRoute}/{id}/print");
        response.EnsureSuccessStatusCode();
    }

    public async Task PrintManyAsync(List<int> ids)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_baseRoute}/print", ids);
        response.EnsureSuccessStatusCode();
    }

    public async Task SetStatusAsync(int id, string status)
    {
        var content = BuildQueryString(new FilterModel { Status = status });
        var response = await _httpClient.PatchAsJsonAsync($"{_baseRoute}/{id}/status{content}", id);
        response.EnsureSuccessStatusCode();
    }
    

    public async Task ActivateAsync(int id) => await SetStatusAsync(id, "Active");
    public async Task DeactivateAsync(int id) => await SetStatusAsync(id, "Inactive");

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