using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        internal List<Language> getAll()
        {
            return _languages;
        }

        internal Language getLanguageByName(string name)
        {
            return _languages.Where(x => x.Name == name).FirstOrDefault();
        }

        internal Language Update(string name, Language newInfo)
        {
            Language dbLanguage = _languages.Where(x => x.Name == name).FirstOrDefault();
            if (dbLanguage == null) { return null; }
            dbLanguage.Name = newInfo.Name;
            return dbLanguage;
        }

        public Language Add(Language language)
        {
            _languages.Add(language);

            return language;
        }

        public Language Delete(string name)
        {
            Language dbLanguage = _languages.Where(x => x.Name == name).FirstOrDefault();
            if (dbLanguage == null) { return null; }
            _languages.Remove(dbLanguage);
            return dbLanguage;
        }
    }
}
