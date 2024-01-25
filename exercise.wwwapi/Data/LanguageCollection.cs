using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection : ILanguageData
    {
        private List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public List<Language> GetLanguages()
        {
            return _languages.ToList();
        }

        public Language GetLanguage(string name)
        {
            Language Language = _languages.FirstOrDefault(Language => Language.Name == name);

            return Language;
        }

        public Language AddLanguage(Language Language)
        {
            _languages.Add(Language);
            return Language;
        }

        public Language UpdateLanguage(string name, LanguagePut language)
        {
            var target = _languages.FirstOrDefault(language => language.Name == name);
            target.Name = language.Name;
            return target;
        }

        public Language DeleteLanguage(string name)
        {
            var languageToremove = _languages.FirstOrDefault(language => language.Name == name);
            if (languageToremove != null)
            {
                _languages.Remove(languageToremove);
                return languageToremove;
            }
            return null;
        }
    }
}
