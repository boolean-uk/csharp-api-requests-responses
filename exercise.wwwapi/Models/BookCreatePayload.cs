namespace exercise.wwwapi.Models
{
    public record BookCreatePayload (string Title, int NumPages, string Author, string Genre);
}
