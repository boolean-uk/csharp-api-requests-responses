using exercise.wwwapi.Core.Models;
using exercise.wwwapi.Extension.Books.Model;

namespace exercise.wwwapi.Core.Data
{

    public class LanguageCollection
    {
        private static List<Language> _languages { get; set; } = new List<Language>();

        public static void Initialize()
        {
            _languages.Add(new Language("Java"));
            _languages.Add(new Language("C#"));
        }

        public Language Add(Language language)
        {
            _languages.Add(language);

            return language;
        }

        public List<Language> getAll()
        {
            return _languages.ToList();
        }

        public bool Remove(string name)
        {
            return _languages.RemoveAll(l => l.name.Equals(name)) > 0 ? true : false;
        }
    }
}
