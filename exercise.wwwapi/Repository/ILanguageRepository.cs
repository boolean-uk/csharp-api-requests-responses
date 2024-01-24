using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        public Language CreateALanguage(string name);

        public List<Language> GetAllLanguages();

        public Language? GetALanguage(string name);

        public Language? UpdateALanguage(string name, LanguageUpdateData updateData);

        public Language DeleteALanguage(string name);
    }
}
