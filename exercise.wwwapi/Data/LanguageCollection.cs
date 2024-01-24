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

        public Language GetLanguage(string name)
        {
            return _languages.Find(x => x.name == name);
        }


        public Language UpdateLanguage(string name)
        {
            Language language = _languages[0];
            language.name = name;
            return language;
        }

        public Language DeleteLanguage(string name)
        {
            Language language= _languages.Find(x => x.name == name);
            _languages.Remove(language);
            return language;
        }
    }
}
