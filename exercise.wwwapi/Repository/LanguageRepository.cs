using exercise.wwwapi.Data;
using exercise.wwwapi.Models.Language;

namespace exercise.wwwapi.Repository
{
    class LanguageRepository : ILanguageRepo
    {
        private LanguageCollection _languages;

        public LanguageRepository(LanguageCollection languages)
        {
            _languages = languages;
        }

        public Language Add(Language language)
        {
            return _languages.Add(language);
        }

        public Language Remove(string language)
        {
            var lang = _languages.Get(language);
            if (lang == null) { return null; }
            return _languages.Remove(lang);
        }

        public List<Language> GetAll()
        {
            return _languages.GetAll();
        }

        public Language Get(string language)
        {
            return _languages.Get(language);
        }

        public Language Update(string language, LanguagePayload payLoad)
        {
            return _languages.Update(language, payLoad);
        }
    }
}
