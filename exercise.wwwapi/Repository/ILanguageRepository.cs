using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        public List<Language> GetLanguages();
        public Language AddLanguage(LanguageCreatePayload languageData);
        public Language GetLanguage(string name);
        public Language UpdateLanguage(string name, LanguageUpdatePayload updateData);
        public Language DeleteLanguage(string name);
    }
}
