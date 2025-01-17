namespace exercise.wwwapi.Models
{
    public class Language
    {
        private string _name {get; set;}
        public string Name 
        { 
            get { return _name;} 
            set { _name = value;} 
        }
        public Language(string name)
        {
            this._name = name;
        }
    }
}
