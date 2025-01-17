using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace exercise.wwwapi.Models
{
    public class Language
    {
        private String name {get; set;}

        public Language(String name)
        {
            this.name = name;
        }

        public string Name {get {return name;}}
    }
}
