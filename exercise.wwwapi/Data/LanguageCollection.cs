using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        public static List<Language> languages = new List<Language>()
        {
            new Language() {name = "Java"},
            new Language() {name = "C#" }
        };

        public static List<Language> GetAll()
        {
            return languages.ToList();
        }

        public static Language Add(Language language)
        {
            languages.Add(language);
            return language;
        }

        public static Language Get(string name)
        {
            return languages.FirstOrDefault(x => x.name == name);
        }

        public static Language Update(Language newLanguage, string name)
        {
            Language lang = languages.FirstOrDefault(x => x.name == name);
            lang.name = newLanguage.name;

            return lang;
        }

        public static Language Delete(string name)
        {
            Language language = Get(name);
            languages.Remove(language);
            return language;
        }
    }
}
