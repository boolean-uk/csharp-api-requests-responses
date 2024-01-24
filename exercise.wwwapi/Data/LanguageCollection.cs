using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection { 
        private List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public IEnumerable<Language> getAll()
        {
            return languages;
        }

        public Language Remove(Language language)
        {
            languages.Remove(language);
            return language;
        }

        public Language Add(Language language) { 
            
            languages.Add(language);
            return language;
        }

    }
}
