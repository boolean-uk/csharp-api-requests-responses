using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> languages = new List<Language>(){
            new Language() {name = "Java"},
            new Language() {name = "C#"}
        };
    }
}
