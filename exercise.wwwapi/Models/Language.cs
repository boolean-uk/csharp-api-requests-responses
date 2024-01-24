namespace exercise.wwwapi.Models
{
    public class Language
    {
        private String name {get; set;}

        public Language(String name)
        {
            this.name = name;
        }

        public String GetName() { return name; }

        public void SetName(String name) { this.name = name;}
    }
}
