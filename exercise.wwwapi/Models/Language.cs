namespace exercise.wwwapi.Models
{
    public class Language : IDatabaseItem
    {
        private String name {get; set;}

        public string Id => new Guid().ToString();

        public Language(String name)
        {
            this.name = name;
        }
    }
}
