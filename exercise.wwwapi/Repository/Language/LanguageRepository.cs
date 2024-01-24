using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private LanguageCollection _languageCollection;

        public LanguageRepository(LanguageCollection languageCollection)
        {
            _languageCollection = languageCollection;
        }

        public List<Language> GetAllLanguages()
        {
            return _languageCollection.languages;
        }

        public Language AddLanguage(string name)
        {
            Language language = new Language(name);

            _languageCollection.Add(language);

            return language;
        }

        public Language? UpdateLanguage(string name, LanguageUpdatePayload languageUpdatePayload)
        {
            var language = _languageCollection.languages.FirstOrDefault(l => l.name == name);

            if (language == null)
            {
                return null;
            }

            if (languageUpdatePayload.Name != null)
            {
                language.name = languageUpdatePayload.Name;
            }

            return language;
        }

        public Language? DeleteLanguage(string name)
        {
            var language = _languageCollection.languages.FirstOrDefault(l => l.name == name);

            if (language == null)
            {
                return null;
            }

            _languageCollection.languages.Remove(language);

            return language;
        }

        public Language? GetLanguage(string name)
        {
            var language = _languageCollection.languages.FirstOrDefault(l => l.name == name);

            if (language == null)
            {
                return null;
            }

            return language;
        }

    }
}