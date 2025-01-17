using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public static Language Add(Language langauage)
        {
            _languages.Add(langauage);
            return langauage;
        }

        public static List<Language> GetAll()
        {
            return _languages.ToList();
        }

        public static Language GetOne(string firstName)
        {
            Language language = _languages.FirstOrDefault(s => s.Name.ToLower() == firstName.ToLower());
            return language;
        }
        public static Language Remove(string firstName)
        {
            Language language = _languages.FirstOrDefault(s => s.Name.ToLower() == firstName.ToLower());
            _languages.Remove(language);
            return language;
        }

        public static Language Update(string firstName, Language update)
        {
            Language language = _languages.FirstOrDefault(s => s.Name.ToLower() == firstName.ToLower());
            language.Name = update.Name;
            return language;
        }
    }
}
