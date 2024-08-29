using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        internal static Language Add(string name)
        {
            if (_languages.Find(x => x._name == name) == null)
            {
                _languages.Add(new Language(name));
            }
            return _languages.FirstOrDefault(x => x.getName() == name);
        }

        internal static Language Delete(string name)
        {
            Language language = null;
            _languages.Remove(language = _languages.FirstOrDefault(y => y.getName() == name));
            return language;
        }

        internal static List<Language> GetAll()
        {
            return _languages;
        }

        internal static Language GetLanguage(string name)
        {
            return _languages.FirstOrDefault(x => x.getName() == name);
        }

        internal static Language UpdateLanguage(Language language)
        {
            Language languageOld = _languages.FirstOrDefault(x => x.getName == language.getName);
            if (languageOld != null)
            {
                languageOld = language;
            }
            return languageOld;
        }
    }
}
