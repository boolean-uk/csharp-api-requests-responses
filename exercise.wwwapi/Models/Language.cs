namespace exercise.wwwapi.Models
{
    public class Language
    {
        private String name {get; set;}
        public String Name { get { return name; } set { name = value; } }

        public Language(String name)
        {
            this.name = name;
        }
    }
}
