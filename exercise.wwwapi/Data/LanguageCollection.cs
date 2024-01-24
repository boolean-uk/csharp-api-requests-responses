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

        public Language AddLanguage(Language language)
        {
            _languages.Add(language);
            return language;
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

        public void updateLanguageByName(string name, string newName)
        {
            foreach (Language language in _languages)
            {
                if (language.name == name)
                {
                    language.name = newName;
                }
            }
        }
    }
}
