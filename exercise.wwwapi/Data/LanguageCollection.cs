using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public List<Language> Get()
        {
            return _languages;
        }

        public Language Get(string name)
        {
            return _languages.FirstOrDefault(l => l.Name == name);
        }

        public Language Add(Language language)
        {
            _languages.Add(language);

            return language;
        }

        public Language Update(string name, Language language) 
        {
            Language existingLanguage = _languages.FirstOrDefault(l => l.Name == name);
            existingLanguage.Name = language.Name;
            return language;
        }

        public Language Remove(string name)
        {
            Language language = _languages.FirstOrDefault(l => l.Name == name);
            _languages.Remove(language);
            return language;
        }
    }
}
