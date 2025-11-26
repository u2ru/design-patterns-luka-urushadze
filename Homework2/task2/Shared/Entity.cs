namespace Shared;

public class SomeEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Status { get; set; }
}

public class SomeImageEntity : SomeEntity
{
    public string? ImageUrl { get; set; }
}

public class FilterModel
{
    public string? Name { get; set; }
    public string? Status { get; set; }
}