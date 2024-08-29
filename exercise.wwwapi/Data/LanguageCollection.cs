using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public static Language AddLanguage(Language t)
        {
            languages.Add(t);
            return t;
        }

        public static Language DeleteLanguage(string name)
        {
            Language lang = languages.FirstOrDefault(new Language(name));
            languages.Remove(lang);
           
            return lang;
        }

        public static List<Language> GetAllLanguages()
        {
            return languages;
        }

        public static Language GetLanguage(string name)
        {
            return languages.FirstOrDefault(new Language(name));
        }

        public static Language UpdateLanguage(string name, Language language)
        {
            Language lang = new Language(name);
            var index = languages.FindIndex(x => x.Equals(lang));
            languages[index] = language;
            return language;
        }

        
    }
}
