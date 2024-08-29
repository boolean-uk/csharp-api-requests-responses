using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public static List<Language> Languages { get => _languages; }

        public static Language Add(Language language)
        {
            _languages.Add(language);

            return language;
        }

        public static List<Language> GetAll()
        {
            return _languages.ToList();
        }

        public static Language GetALanguage(string name)
        {
            return _languages.FirstOrDefault(language => language.name == name);
        }

        public static Language UpdateLanguage(string name, Language language)
        {
            int index = _languages.FindIndex(language => language.name == name);
            _languages[index] = language;

            return language;
        }

        public static Language DeleteLanguage(string name)
        {
            var language = _languages.FirstOrDefault(language => language.name == name);
            _languages.Remove(language);

            return language;
        }
    }
}
