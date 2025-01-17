using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> languages = new List<Language>();

        public static void Initialize()
        {
            languages.Add(new Language("Java" ));
            languages.Add(new Language("C#"));
        }


        public static Language Get(string firstName)
        {
            return languages.FirstOrDefault(p => p.Name == firstName);
        }
        public static Language Add(Language entity)
        {
            languages.Add(entity);
            return entity;

        }
        public static bool Remove(string FirstName)
        {
            return languages.RemoveAll(p => p.Name == FirstName) > 0 ? true : false;

        }

        public static List<Language> Languages { get { return languages; } }

    }
}
