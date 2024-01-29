using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class LanguageCollection
    {
        private List<Language> _languages = new List<Language>()
        {
            new Language("Java"),
            new Language("C#")
        };

        public Language AddLanguage(string languageName)
        {
            Language newLanguage = new Language(languageName);
            _languages.Add(newLanguage);
            return null;
        }

        public List<Language> GetList()
        {
            return _languages.ToList();
        }

        public Language GetLanguageByName(string name) 
        {
            foreach (Language language in _languages) 
            {
                if (language.name == name) 
                {
                    return language; 
                }
            }
            return null;
        }

        public Language? DeleteLanguage(string languageName)
        {
            var language = _languages.FirstOrDefault(x => x.name == languageName);
            if (language != null)
            {
                _languages.Remove(language);
                return language;
            }
            return null;
        }
    }
}
