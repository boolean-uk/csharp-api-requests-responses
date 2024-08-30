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

        public static Language Delete(string Name)
        {
            Language language = languages.FirstOrDefault(x => x.name == Name);
            if (language != null) languages.Remove(language);
            return language;
        }

        public static Language Get(string Name)
        {
            Language language = languages.FirstOrDefault(x => x.name == Name);
            return language;
        }

        public static Language Update(string Name, Language language)
        {
            Language languageToUpdate = languages.FirstOrDefault(y => y.name == Name);
            languageToUpdate.name = language.name;
            return languageToUpdate;
        }

        public static List<Language> getAll()
        {
            return languages.ToList();
        }
    }
}
