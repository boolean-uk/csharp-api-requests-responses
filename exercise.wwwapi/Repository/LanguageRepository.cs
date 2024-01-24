using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {

        private LanguageCollection _languages;
        public LanguageRepository(LanguageCollection language) { 
            _languages = language;
        }
        public Language AddLanguage(LanguagePostPayload payload)
        {
            return _languages.AddLanguage(payload);
        }

        public void deleteLanguage(string name)
        {
            _languages.deteleLanguageByName(name);
        }

        public List<Language> getAllLanguages()
        {
            return _languages.getAllLanguages();
        }

        public Language GetLanguageByName(string name)
        {
            return _languages.getLanguageByName(name);
        }

        public Language UpdateLanguage(string name, LanguagePutPayload payload)
        {
            Language tmpLanguage = _languages.getLanguageByName(name);
            if (tmpLanguage == null)
            {
                return null;
            }


            bool isUpdated = false;

            if (payload.name != null && payload.name.Length > 0) {
                tmpLanguage.Name = payload.name;
                isUpdated = true;
            }

            if (!isUpdated)
            {
                throw new Exception("No changes was entered");
            }

            return tmpLanguage;
        }
    }
}
