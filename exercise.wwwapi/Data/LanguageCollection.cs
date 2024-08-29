using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };


        public static List<Language> getAll()
        {
            return _languages.ToList();
        }

        public static Language getOne(string name)
        {
            return _languages.FirstOrDefault(x => x.name.Equals(name));
        }
        public static Language Add(Language language)
        {
            _languages.Add(language);

            return language;
        }

        public static Language Update(string name, Language language)
        {
            Language toReplace = _languages.FirstOrDefault(x => x.name.Equals(name));
            _languages[_languages.IndexOf(toReplace)] = language;

            return language;
        }

        public static Language Delete(string name)
        {
            Language toDelete = _languages.FirstOrDefault(x => x.name.Equals(name));
            _languages.Remove(toDelete);

            return toDelete;
        }
    }
}
