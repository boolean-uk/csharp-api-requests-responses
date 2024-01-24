using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        public List<Language> GetAllLang();

        public Language AddLanguage(string name);

        public Language? GetLanguage(int id);

        public Language? UpdateLanguage(Language language, LanguageUpdatePayload updateData);

        public List<Language> DeleteLanguage(int id);
    }
}
