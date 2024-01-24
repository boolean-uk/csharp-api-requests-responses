namespace exercise.wwwapi.Models

{
    public record BookUpdatePayload(string? Title, int? NumPage, string? Author, string? Genre);
}