using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection : ILanguageData
    {
        private List<Language> _languages = new List<Language>()
        {
            new Language("Java"),
            new Language("C#")
        };

        public List<Language> GetAll()
        {
            return _languages.ToList();
        }

        public Language Add(Language language)
        {
            _languages.Add(language);

            return language;
        }

        public Language Get(string name)
        {
            return _languages.FirstOrDefault(s => s.Name == name);
        }

        public Language Update(string name, Language language)
        {
            var target = _languages.FirstOrDefault(l => l.Name == name);
            target.Name = language.Name;
            return target;
        }

        public Language Delete(string name)
        {
            Language language = _languages.FirstOrDefault(s => s.Name == name);
            _languages.Remove(language);
            return language;
        }
    }
}
