using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public void Add(Language language)
        {
            _languages.Add(language);
        }

        public List<Language> GetAll()
        {
            return _languages;
        }

        public void Delete(Language language)
        {
            _languages.Remove(language);
        }
    }
}
