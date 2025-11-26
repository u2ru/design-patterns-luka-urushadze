// See https://aka.ms/new-console-template for more information
using ClientLibrary;
using Shared;

using var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("http://localhost:5012/");

Console.WriteLine("=== Testing API Clients ===");

try
{
    await Task.Delay(2000);
    
    // CRUD client
    await TestCrudClient(httpClient);
    
    // Flexible client
    await TestFlexibleClient(httpClient);
    
    // Image client
    await TestImageClient(httpClient);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();

async Task TestCrudClient(HttpClient client)
{
    Console.WriteLine("\n--- Testing CRUD Client ---");
    
    ICrudApiClient crudClient = new CrudApiClient(client);
    
    // Create
    var newEntity = new SomeEntity 
    { 
        Name = "Test entity",
        Status = "Active" 
    };
    var created = await crudClient.CreateAsync(newEntity);
    Console.WriteLine($"Created: ID={created.Id}, Name={created.Name}");
    
    // Read
    var retrieved = await crudClient.GetOneAsync(created.Id);
    Console.WriteLine($"Retrieved: {retrieved.Name}");
    
    // Update
    retrieved.Status = "Inactive";
    var updated = await crudClient.UpdateAsync(retrieved);
    Console.WriteLine($"Updated: {updated.Status}");
    
    // Get Many
    var allEntities = await crudClient.GetManyAsync();
    Console.WriteLine($"Total entities: {allEntities.Count}");
    
    // Delete
    await crudClient.DeleteAsync(created.Id);
    Console.WriteLine("Deleted entity");
}

async Task TestFlexibleClient(HttpClient client)
{
    Console.WriteLine("\nTesting Flexible Client");
    
    IFlexibleApiClient flexibleClient = new FlexibleApiClient(client);
    
    // test data
    var entity1 = await flexibleClient.CreateAsync(new SomeEntity 
    { 
        Name = "Flexible Test 1",
        Status = "Active" 
    });
    
    var entity2 = await flexibleClient.CreateAsync(new SomeEntity 
    { 
        Name = "Flexible Test 2",
        Status = "Inactive" 
    });
    
    // Filter
    var filter = new FilterModel { Name = "Flexible Test 2" };
    var filtered = await flexibleClient.GetByFilterAsync(filter);
    Console.WriteLine($"Filtered active entities: {filtered.Count}");
    
    // Status operations
    await flexibleClient.DeactivateAsync(entity1.Id);
    Console.WriteLine("Deactivated entity");
    
    await flexibleClient.ActivateAsync(entity1.Id);
    Console.WriteLine("Activated entity");
    
    // Print operations
    await flexibleClient.PrintAsync(entity1.Id);
    Console.WriteLine("Printed single entity");
    
    await flexibleClient.PrintManyAsync(new List<int> { entity1.Id, entity2.Id });
    Console.WriteLine("Printed multiple entities");
    
    // Cleanup
    await flexibleClient.DeleteAsync(entity1.Id);
    await flexibleClient.DeleteAsync(entity2.Id);
}

async Task TestImageClient(HttpClient client)
{
    Console.WriteLine("\nTesting Image Client");
    
    IImageApiClient imageClient = new ImageApiClient(client);
    
    // Create image entity
    var imageEntity = new SomeImageEntity 
    { 
        Name = "Image Entity",
        Status = "Active",
        ImageUrl = "https://refactoring.guru/images/content-public/logos/logo-new-2x.png?id=3bc33294e095bab1d6fe9ae421d07837"
    };
    
    var created = await imageClient.SetImageAsync(imageEntity);
    Console.WriteLine($"Created Image Entity: {created.Name}, ImageUrl: {created.ImageUrl}");
    
    // Get by ID
    var retrieved = await imageClient.GetImageAsync(created.Id);
    Console.WriteLine($"Retrieved Image Entity: {retrieved.Name}");
    
    // Get by filter
    var filter = new FilterModel { Name = "Image Entity" };
    var images = await imageClient.GetEntitiesByFilterAsync(filter);
    Console.WriteLine($"Image entities count: {images.Count}");
}