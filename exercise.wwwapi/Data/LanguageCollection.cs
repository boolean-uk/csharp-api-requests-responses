using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public static Language Add(Language language) //Add the given language to the list
        {
            _languages.Add(language);

            return language;
        }

        public static List<Language> GetAll() //Get all languages in the list
        {
            return _languages;
        }

        public static Language Get(string name) //Get the language with the given name
        {
            var language = _languages.FirstOrDefault(x => x.name == name);
            return language;
        }

        public static Language Remove(string name) //Remove the language with the given name
        {
            var language = _languages.FirstOrDefault(x => x.name == name);
            _languages.Remove(language);
            return language;
        }

        public static Language Update(Language newLanguage, string name) //Replace the language that has the given name with the new language
        {
            int index = _languages.IndexOf(_languages.FirstOrDefault(x => x.name == name));
            if (index != -1)
            {
                _languages[index] = newLanguage;
            }
            return _languages[index];
        }
    }
}
