using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public static Language Add(Language entity)
        {
            languages.Add(entity);

            return entity;
        }

        public static Language DeleteLanguage(string name)
        {
            var language = languages.FirstOrDefault(x => x.name == name);
            languages.Remove(language);
            return language;
        }

        public static List<Language> GetAll()
        {
            return languages.ToList();
        }

        public static Language GetLanguage(string name)
        {
            var language = languages.FirstOrDefault(x => x.name == name);
            return language;
        }

        public static Language UpdateLanguage(Language newLanguage, string name)
        {
            var language = languages.FirstOrDefault(x => x.name == name);
            language.name = newLanguage.name;
            return language;
        }
    }
}
