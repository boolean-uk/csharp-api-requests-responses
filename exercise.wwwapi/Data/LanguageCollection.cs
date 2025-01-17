using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public static Language Add(Language language)
        {
            languages.Add(language);

            return language;
        }

        public static List<Language> getAll()
        {
            return languages.ToList();
        }

        public static Language Get(string name)
        {
            return languages.FirstOrDefault(l => l.Name == name);
        }

        public static Language Remove(string name)
        {
            Language language = languages.FirstOrDefault(l => l.Name == name);
            languages.Remove(language);
            return language;
        }

    }
}
