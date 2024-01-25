using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection : IData<Language>
    {
        private List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public IEnumerable<Language> GetAll()
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
            var targetLanguage = _languages.FirstOrDefault(l => l.Name == name);
            targetLanguage.Name = language.Name;
            return targetLanguage;

        }

        public Language Delete(string name)
        {
            var language = _languages.FirstOrDefault(l => l.Name == name);

            _languages.Remove(language);

            return language;
        }

    }
}
