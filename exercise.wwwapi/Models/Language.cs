namespace exercise.wwwapi.Models
{
    public class Language
    {
        public String name {get; set;}

        public Language(String name)
        {
            this.name = name;
        }

        public String GetName()
        {
            return this.name;
        }

        public String SetName(string name)
        {
            this.name = name;
            return name;
        }
    }
}
