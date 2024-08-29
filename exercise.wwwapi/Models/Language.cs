namespace exercise.wwwapi.Models
{
    public class Language
    {
        private string _name {get; set;}

        public Language(String name)
        {
            this._name = name;
        }

        public string Name { get => _name; set => _name = value; }
    }
}
