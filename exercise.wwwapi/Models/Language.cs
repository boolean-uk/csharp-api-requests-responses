namespace exercise.wwwapi.Models
{
    public class Language
    {
        private string _name;
        public string Name { get => _name; set => _name = value; }
        public Language(string name)
        {
           _name = name;
        }

      
               
    }
}
