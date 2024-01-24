using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection : ILanguageRepository
    {
        private List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public Language Add(Language language)
        {
            _languages.Add(language);
            return language;
        }

        public List<Language> GetAll()
        {
            return _languages.ToList();
        }

        public Language Get(string name)
        {
            return _languages.FirstOrDefault(l => l.Name == name);
        }

        public Language Update(string name , Language updatedLanguage)
        {
            var language = _languages.FirstOrDefault(l => l.Name == name);
            if(language != null)
            {
                language.Name = updatedLanguage.Name;
            }
            return language;
        }

        public Language Delete(string name)
        {
            var language = _languages.FirstOrDefault(l => l.Name == name);
            if(language != null)
            {
                _languages.Remove(language);
            }
            return language;
        }
    }
}
