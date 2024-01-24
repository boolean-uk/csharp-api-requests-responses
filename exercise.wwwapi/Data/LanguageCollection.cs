using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public List<Language> GetAll() {
            return languages;
        }

        public Language Add(Language language) {
            languages.Add(language);
            return language;
        }

        public Language Remove(string languageName) {
            Language language = Get(languageName);
            languages.Remove(language);
            return language;
        }

        public Language? Get(string name) {
            return languages.FirstOrDefault(t => t.Name == name);
        }
    }
}
