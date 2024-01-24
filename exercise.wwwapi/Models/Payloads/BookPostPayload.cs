namespace exercise.wwwapi.Models.Payload
{
    public record BookPostPayload(string title, int numPages, string author, string genre);
}