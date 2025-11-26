// See https://aka.ms/new-console-template for more information

using System.Net.Http.Json;
using Shared;

Console.WriteLine("Client Console App Started");


var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("http://localhost:5012/");
var newEntity = new SomeEntity
{
    Name = "Test Entity",
    Description = "This is a test entity",
    Status = "Active"
};

// sleep for 2 seconds to allow the API to start
Console.WriteLine("Waiting for API to start...");
await Task.Delay(2000);

try
{
    var response = await httpClient.PostAsJsonAsync("api/someentity", newEntity);
    if (response.IsSuccessStatusCode)
    {
        var createdEntity = await response.Content.ReadFromJsonAsync<SomeEntity>();
        Console.WriteLine($"Created Entity: ID={createdEntity.Id}, Name={createdEntity.Name}");
    }
    else
    {
        Console.WriteLine($"Error: {response.StatusCode}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Exception: {ex.Message}");
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();