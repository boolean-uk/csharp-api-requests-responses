namespace exercise.wwwapi.Models
{
    public record BookUpdatePayload(string? Title, int? numPages, string? Author, string genre);
    
}
