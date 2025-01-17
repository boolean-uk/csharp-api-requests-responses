using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class LanguageCollection
    {
        private static List<Language> languages = new List<Language>()
        {
            new Language("Java"),
            new Language("C#"),
        };

        public static List<Language> GetAll()
        {
            return languages;
        }

        public static Language Add(Language language)
        {
            languages.Add(language);
            return language;
        }
    }
}
