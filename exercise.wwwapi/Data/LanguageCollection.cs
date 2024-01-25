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

        public List<Language> getAll()
        {
            return _languages.ToList();
        }

        public Language GetLanguage(string languageName)
        {
            Language language = _languages.FirstOrDefault(s => s.GetName() == languageName);
            return language;
        }

        public Language RemoveLanguage(string languageName)
        {
            Language language = _languages.FirstOrDefault(s => s.GetName() == languageName);
            _languages.Remove(language);
            return language;
        }

        public Language UpdateLanguage(string languageName, Language languageUpdate)
        {
            Language language = _languages.FirstOrDefault(s => s.GetName() == languageName);
            language.SetName(languageName);
            return language;
        }
    }
}
    

