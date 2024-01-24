using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private LanguageCollection _languages;
        public LanguageRepository(LanguageCollection languages)
        {
            _languages = languages;
        }

        public List<Language> GetAllLanguages()
        {
            return _languages.GetAll();
        }
        
        public Language AddLanguage(string name)
        {
            return _languages.AddLanguage(name);
        }

        public Language? GetLanguage(string name)
        {
            return _languages.GetLanguage(name);
        }

        public Language? UpdateLanguage(string name, LanguageUpdatePayload updateData)
        {
            var language = _languages.GetLanguage(name);
            if (language == null)
            {
                return null;
            }

            bool hasUpdate = false;

            if (updateData.name != null)
            {
                language.SetName((string)updateData.name);
                hasUpdate = true;
            }

            if (!hasUpdate) throw new Exception("No update data provided");

            return language;
        }

        public Language? RemoveLanguage(string name)
        {
            Language language = _languages.GetLanguage(name);
            if (language == null)
            {
                return null;
            }
            if (language.Name != null)
            {
                _languages.RemoveLanguage(language);
            }
            return language;
        }
    }
}
