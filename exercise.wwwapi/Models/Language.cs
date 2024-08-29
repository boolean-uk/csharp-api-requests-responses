namespace exercise.wwwapi.Models
{
    public class Language
    {
        //it being private gave me problems with visibility
        public string _name {get; set;}

        public Language(string name)
        {
            this._name = name;
        }

        public string getName() { return _name;}
    }
}
