namespace request_response.Models
{
    public class Language
    {
        private string _name;
        public string name { get { return _name; } set { _name = value; } }

        public Language(string name)
        {
            this.name = name;
        }
    }
}
