namespace exercise.wwwapi.Models
{
    public class Language
    {
       public string Name { get; set; }
        public int Id { get; }

        public Language(int languageId, string name)
        {
            Id = languageId;
            Name = name;
        }
    }
}
