using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>()
        {
            new Language(){ Name="Java" },
            new Language(){ Name="C#" }
        };

        public static Language Add(Language language)
        {
            _languages.Add(language);

            return language;
        }

        public static Language Get(string name)
        {
            return _languages.FirstOrDefault(x => x.Name.Equals(name));
        }

        public static List<Language> GetAll()
        {
            return _languages.ToList();
        }

        public static Language Delete(string name)
        {
            var language = _languages.FirstOrDefault(x => x.Name.Equals(name));
            if (language == null) return null;
            _languages.Remove(language);
            return language;
        }

        public static Language Update(string name, Language entity)
        {
            var language = _languages.FirstOrDefault(x => x.Name.Equals(name));
            if (language == null) return null;
            language.Name = entity.Name;
            return language;
        }
    };
}
