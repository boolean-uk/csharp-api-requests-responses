namespace exercise.wwwapi.Models
{
    public record BookUpdatePayload (string Title, int? NumPages, string Author, string Genre);

}
