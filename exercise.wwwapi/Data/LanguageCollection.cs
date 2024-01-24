using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>() {
            new Language("Java"),
            new Language("C#")
        };

        public Language Add(Language language)
        {
            _languages.Add(language);

            return language;
        }

        public Language Remove(Language language)
        {
            _languages.Remove(language);

            return language;
        }

        public List<Language> GetAll()
        {
            return _languages.ToList();
        }
    }
}
