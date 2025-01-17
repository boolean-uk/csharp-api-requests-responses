namespace exercise.wwwapi.Models;

public record Book
{
    public required int id { get; set; }
    public required string title { get; set; }
    public required int numPages { get; set; }
    public required string author { get; set; }
    public required string genre { get; set; }
}
