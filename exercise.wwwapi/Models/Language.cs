namespace exercise.wwwapi.Models
{
    public class Language
    {
        private String _name;
        public String name { get => _name; set => _name = value; }

        public Language(String name)
        {
            this._name = name;
        }
        public Language() { }
        
    }
}
