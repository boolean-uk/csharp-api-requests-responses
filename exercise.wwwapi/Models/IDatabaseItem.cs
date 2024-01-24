namespace exercise.wwwapi.Models
{
    public abstract class DatabaseItem
    {
        public string Id { get; } = Guid.NewGuid().ToString();
    }
}
