using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>();

        public static void Intizialize()
        {
            _languages.Add(new Language("Java"));
            _languages.Add(new Language("C#"));
        }

        public static Language Add(Language language)
        {
            _languages.Add(language);
            return language;
        }
        public static List<Language> GetAll()
        {
            return _languages;
        }
        public static Language GetOne(string name)
        {
            return _languages.Find(x => x.name  == name);
        }
        public static bool Delete(string name) 
        {
            return _languages.RemoveAll(x => x.name == name) > 0 ? true: false;
        }
    }
}
