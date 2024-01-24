using System.Xml.Linq;

namespace exercise.wwwapi.Models
{
    public class Language
    {
        public String Name {get; set;}

        public Language(String name)
        {
            Name = name;
        }
        public String getName() { return Name; }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
