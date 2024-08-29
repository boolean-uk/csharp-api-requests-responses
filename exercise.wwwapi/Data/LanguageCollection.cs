using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public LanguageCollection() { }

        public List<Language> Languages { get { return languages; } }

        public Language AddLanguage (Language language)
        {
            languages.Add(language);
            return language;
        }
    }
}
