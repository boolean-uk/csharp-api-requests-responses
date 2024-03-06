using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class LanguageCollection
    {
        public List<Language> languages = new List<Language>(){
            new Language() { Id = 1, name = "Java"},
            new Language() { Id = 2, name = "C#" }
        };
    }
}
