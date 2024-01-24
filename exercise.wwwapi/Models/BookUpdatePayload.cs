namespace exercise.wwwapi.Models
{
    public record BookUpdatePayload(string? title, int? numPages, string? author, string? genre)
    {

    }
}
