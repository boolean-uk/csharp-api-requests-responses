using System.Net.NetworkInformation;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>();

        public static void Initialize()
        {
            _languages.Add(new Language("Java"));
            _languages.Add(new Language("C#"));
        }

        public static Language Add(Language language)
        {
            _languages.Add(language);
            return language;
        }

        public static List<Language> GetLanguages()
        {
            return _languages.ToList();
        }

        public static Language GetLanguage(string name)
        {
            return _languages.FirstOrDefault(p => p.name.ToLower() == name.ToLower());
        }

        public static bool RemoveLanguage(string name)
        {
            return _languages.RemoveAll(p => p.name.ToLower() == name.ToLower()) > 0 ? true : false; ;
        }
    }
}
