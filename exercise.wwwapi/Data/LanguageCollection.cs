using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> languages = new List<Language>(){
            new Language() { name = "C#" },
            new Language() { name = "Python" }
        };

        public static Language AddLanguage(Language language)
        {
            languages.Add(language);

            return language;
        }

        public static List<Language> GetLanguages()
        {
            return languages;
        }

        public static Language GetLanguageByName(string name)
        {
            foreach (Language language in languages)
            {
                if (language.name.ToLower() == name.ToLower())
                {

                    return language;
                }
            }


            return null;
        }

        public static Language UpdateLanguageInfo(string old, string newName)
        {
            string oldd = old.ToLower();
            Language language = GetLanguageByName(oldd);
            if (language != null)
            {
                language.name = newName;
                return language;
            }

            return null;
        }

        public static Language DeleteLanguage(string name)
        {
            Language language = GetLanguageByName(name);
            Language removedLanguage;
            if (language != null)
            {
                removedLanguage = language;
                languages.Remove(language);
                return removedLanguage;
            }

            return null;
        }
    }
}
