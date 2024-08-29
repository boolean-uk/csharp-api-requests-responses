using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> _languages = new List<Language>(){
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
            var language = _languages.Find(x => x.Name == name);

            return language;
        }

        public Language Update(string name, Language language)
        {
            int  index = _languages.FindIndex(x => x.Name == name);
            if (index == -1)
                return null;

            _languages[index] = language;

            return language;
        }

        public Language Delete(string name)
        {
            Language deletedLanguage = _languages.Find(x => x.Name == name);
            _languages.Remove(deletedLanguage);

            return deletedLanguage;
        }
    }
}
