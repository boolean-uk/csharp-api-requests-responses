namespace exercise.wwwapi.Models
{
    public class Language
    {
        private String name {get; set;}
        public String Name { get { return name;}}
        public Language(String name)
        {
            this.name = name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
    }
}
