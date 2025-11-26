using Scalar.AspNetCore;
using Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var entities = new List<SomeEntity>();
var imageEntities = new List<SomeImageEntity>();
var nextId = 1;
var nextImageId = 1;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.MapGet("/", () => "Hello World!").WithName("Index");

//
app.MapGet("/api/someentity", () => Results.Ok(entities));

app.MapGet("/api/someentity/{id}", (int id) =>
{
    var entity = entities.FirstOrDefault(e => e.Id == id);
    return entity != null ? Results.Ok(entity) : Results.NotFound();
});

app.MapPost("/api/someentity", (SomeEntity entity) =>
{
    entity.Id = nextId++;
    entities.Add(entity);
    return Results.Created($"/api/someentity/{entity.Id}", entity);
});

app.MapPut("/api/someentity/{id}", (int id, SomeEntity entity) =>
{
    var existing = entities.FirstOrDefault(e => e.Id == id);
    if (existing == null) return Results.NotFound();
    
    existing.Name = entity.Name;
    existing.Description = entity.Description;
    existing.Status = entity.Status;
    
    return Results.Ok(existing);
});

app.MapDelete("/api/someentity/{id}", (int id) =>
{
    var entity = entities.FirstOrDefault(e => e.Id == id);
    if (entity == null) return Results.NotFound();
    
    entities.Remove(entity);
    return Results.NoContent();
});

app.MapDelete("/api/someentity", (int[] ids) =>
{
    entities.RemoveAll(e => ids.Contains(e.Id));
    return Results.NoContent();
});

app.MapGet("/api/someentity/filter", (string? name, string? status) =>
{
    var query = entities.AsQueryable();

    if (!string.IsNullOrEmpty(name))
    {
        query = query.Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    if (!string.IsNullOrEmpty(status))
    {
        query = query.Where(e => e.Status == status);
    }
        
    var result = query.ToList();
    
    return Results.Ok(result);
});

app.MapGet("/api/someentity/{id}/print", (int id) =>
{
    var entity = entities.FirstOrDefault(e => e.Id == id);
    return entity != null 
        ? Results.Ok($"Printed: {entity.Name} - {entity.Description}") 
        : Results.NotFound();
});

app.MapPost("/api/someentity/print", (int[] ids) =>
{
    var entitiesToPrint = entities.Where(e => ids.Contains(e.Id));
    var result = string.Join(", ", entitiesToPrint.Select(e => e.Name));
    return Results.Ok($"Printed entities: {result}");
});

app.MapPatch("/api/someentity/{id}/status", (int id, string status) =>
{
    var entity = entities.FirstOrDefault(e => e.Id == id);
    if (entity == null) return Results.NotFound();
    
    entity.Status = status;
    return Results.Ok(entity);
});

app.MapPost("/api/someentity/{id}/deactivate", (int id) =>
{
    var entity = entities.FirstOrDefault(e => e.Id == id);
    if (entity == null) return Results.NotFound();
    
    entity.Status = "Inactive";
    return Results.Ok(entity);
});

app.MapPost("/api/someentity/{id}/activate", (int id) =>
{
    var entity = entities.FirstOrDefault(e => e.Id == id);
    if (entity == null) return Results.NotFound();
    
    entity.Status = "Active";
    return Results.Ok(entity);
});

// SomeImageEntity endpoints
app.MapGet("/api/someimageentity/{id}", (int id) =>
{
    var entity = imageEntities.FirstOrDefault(e => e.Id == id);
    return entity != null ? Results.Ok(entity) : Results.NotFound();
});

app.MapPost("/api/someimageentity", (SomeImageEntity entity) =>
{
    if (entity.Id == 0)
    {
        entity.Id = nextImageId++;
        imageEntities.Add(entity);
        return Results.Created($"/api/someimageentity/{entity.Id}", entity);
    }
    else
    {
        var existing = imageEntities.FirstOrDefault(e => e.Id == entity.Id);
        if (existing == null) return Results.NotFound();
        
        existing.Name = entity.Name;
        existing.Description = entity.Description;
        existing.Status = entity.Status;
        existing.ImageUrl = entity.ImageUrl;
        
        return Results.Ok(existing);
    }
});

app.MapGet("/api/someimageentity/filter", (string? name, string? description, string? status, int page = 1, int pageSize = 10) =>
{
    var query = imageEntities.AsQueryable();
    
    if (!string.IsNullOrEmpty(name))
        query = query.Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        
    if (!string.IsNullOrEmpty(description))
        query = query.Where(e => e.Description.Contains(description, StringComparison.OrdinalIgnoreCase));
        
    if (!string.IsNullOrEmpty(status))
        query = query.Where(e => e.Status == status);
        
    var result = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
    return Results.Ok(result);
});
//

app.Run();
