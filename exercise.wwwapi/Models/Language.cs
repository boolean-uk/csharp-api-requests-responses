namespace exercise.wwwapi.Models
{
    public class Language
    {
        public string name {get; set;} //changed to public

        public  Language(string name)
        {
            this.name = name;
        }
    }
}
