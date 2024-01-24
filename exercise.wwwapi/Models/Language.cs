namespace exercise.wwwapi.Models
{
    public class Language(string name) : DatabaseItem
    {
        public string Name { get; set; } = name;
    }
}
