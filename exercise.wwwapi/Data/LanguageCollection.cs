using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>()
        {
            new Language("Java"),
            new Language("C#")
        };
        public static Language Add(Language language)
        {
            _languages.Add(language);

            return language;
        }

        public static List<Language> getAll()
        {
            return _languages.ToList();
        }
        public static Language GetA(string languageName)
        {
            return _languages.FirstOrDefault(x => x.name == languageName);
        }

        public static Language Change(string search, Language entity)
        {
            foreach (var language in _languages)
            {
                if (language.name == search)
                {
                    language.name = entity.name;
                }
            }
            return entity;
        }
        public static string Delete(string search)
        {
            foreach (var language in _languages)
            {
                if (language.name.Equals(search))
                {
                    _languages.Remove(language);
                    return search;
                }

            }
            return null;
        }
    }
}
