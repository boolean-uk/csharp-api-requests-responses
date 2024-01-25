namespace exercise.wwwapi.Models
{
    public class Language
    {
        private String name {get; set;}

        public Language(String name)
        {
            this.name = name;
        }
        public string GetName() { return name;}
        public void SetName(string name) { this.name = name;}
    }
}
