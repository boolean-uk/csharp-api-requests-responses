using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private static List<Language> _language = new List<Language>();

        public static void Initialize()
        {
            _language.Add(new Language { Name = "Java" });
            _language.Add(new Language { Name = "Csharp" });
        }
        public static List<Language> Languages { get { return _language; } }

        public static Language Get(string Name)
        {
            return _language.FirstOrDefault(l => l.Name == Name);
        }
        public static Language Add(Language language)
        {
            var existingLanguage = _language.FirstOrDefault(l => l.Name == l.Name);
            if (existingLanguage != null)
            {
                _language.Add(language);
            }
            return language;
        }
        public static Language Update(string name, Language language)
        {
            var existingLanguage = _language.FirstOrDefault(l => l.Name == name);
            if (existingLanguage != null)
            {
                existingLanguage.Name = language.Name;
                
            }
            return existingLanguage;
        }
        public static bool Delete(string name)
        {
            return _language.RemoveAll(l => l.Name == name) > 0 ? true : false;
        }
    }
}
