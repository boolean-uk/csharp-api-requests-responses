
namespace exercise.wwwapi
{
    public class LanguageCollection
    {
        private List<Language> _languages = new List<Language>()
        {
            new Language("Java"),
            new Language("C#")
        };

        public Language Add(Language language)
        {
            _languages.Add(language);
            return language;
        }

        public List<Language> GetAll()
        {
            return _languages.ToList();
        }

        public Language Get(string name)
        {
            return _languages.FirstOrDefault(l => l.Name == name);
        }

        public Language Update(string oldName, string newName)
        {
            var language = _languages.FirstOrDefault(x => x.Name == oldName);
            if (language != null)
            {
                language.Name = newName;
                return language;
            }
            return null;
        }

        public bool Delete(string name)
        {
            var languageToRemove = _languages.FirstOrDefault(x => x.Name == name);
            if (languageToRemove != null)
            {
                return _languages.Remove(languageToRemove);
            }
            return false;
        }
    }
}
