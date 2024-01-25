namespace exercise.wwwapi.Models
{
    public class Language
    {
        private string _name;

        public Language(string name)
        {
            _name = name;
        }

        public string Name { get { return _name; } set { _name = value; } }
    }
}
