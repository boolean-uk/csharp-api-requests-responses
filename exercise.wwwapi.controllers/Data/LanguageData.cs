using exercise.wwwapi.controllers.Models;

namespace exercise.wwwapi.controllers.Data
{
    public class LanguageData
    {
        private  static List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C++"),
            new Language("Go"),
            new Language("Rust"),
            new Language("C#")
        };

        public static List<Language> GetAll()
        {
            return _languages.ToList();
        }

        public static Language Add(Language language)
        {
            _languages.Add(language);

            return language;
        }
        public static bool Delete(Language language)
        {
            if (_languages.Contains(language))
            {
                _languages.Remove(language);
                return true;

            }

            return false;
        }

    }
}
