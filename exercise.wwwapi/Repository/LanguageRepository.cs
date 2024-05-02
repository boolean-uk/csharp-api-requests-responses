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
            return _languages.Languages;
        }
        public Language AddLanguage(string name)
        {
            return _languages.AddLanguage(name);
        }

        public Language? GetLanguage(string name)
        {
            return _languages.GetLanguage(name);
        }

        public Language? UpdateLanguage(string name, LanguageUpdatePayload updateLanguage)
        {
            var language = _languages.GetLanguage(name);
            if(language == null)
            {
                return null;
            }
            bool isUpdated = false;

            // TODO finish the updateLanguage
            if(updateLanguage.Name != null)
            {
                language.Name = (string)updateLanguage.Name;
                isUpdated = true;
            }
            if (!isUpdated) throw new Exception("Language is not updated.");
            return language;
        }

        public Language DeleteLanguage(string name)
        {
            return _languages.DeleteLanguage(name);
        }

    }
}
