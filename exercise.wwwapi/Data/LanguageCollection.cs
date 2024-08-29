using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public static Language Add(Language language) { 
            languages.Add(language);
            return language;
        }

        public static List<Language> GetLanguages()
        {
            return languages;
        }

        public static Language Get(string name)
        {
            return languages.Find(l => l.name.ToLower() == name.ToLower());
        }

        public static Language Update(string name, Language updated)
        {
            Language l = languages.Find(l => l.name.ToLower() == name.ToLower());
            l.name = updated.name;
            return l;
        }

        public static Language Delete(string name)
        {
            Language l = languages.Find(l => l.name.ToLower() == name.ToLower());
            languages.Remove(l);
            return l;
        }
    }
}
