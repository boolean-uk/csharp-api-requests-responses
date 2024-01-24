namespace exercise.wwwapi.Models.Payload
{
    public record BookUpdatePayload(string? Title, int? NumPages, string? Author, string? Genre);
}