namespace exercise.wwwapi.Models
{
    public class Language
    {
        private string _name {get; set;}

        public Language(string name)
        {
            this._name = name;
        }

        public string getName() { return _name;}
    }
}
