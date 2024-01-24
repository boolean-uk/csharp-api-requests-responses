using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        public List<Language> getAllLanguages();
        public Language? GetLanguageByName(string name);
        public Language AddLanguage(LanguagePostPayload payload);
        public void deleteLanguage(string name);
        public Language UpdateLanguage(string name, LanguagePutPayload payload);
    }
}
