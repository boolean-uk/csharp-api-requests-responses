namespace exercise.wwwapi.Models
{
    public class Language
    {
        private String _name {get; set;}

        public String Name { get { return _name;} }

        public Language(String name)
        {
            _name = name;
        }

        public void Update(string name)
        {
            _name = name;
        }
    }
}
