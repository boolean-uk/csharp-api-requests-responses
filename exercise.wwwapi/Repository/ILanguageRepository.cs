
using exercise.wwwapi.Models;
using exercise.wwwapi.Models.Payload;


namespace exercise.wwwapi.Repository {

    public interface ILanguageRepository {

        public List<Language> GetAllLanguages();
        public Language AddLanguage(string Name);

        public Language? GetLanguage(string Name);

        public Language? DeleteLanguage(string Name);
        public Language? UpdateLanguage(string Name, LanguageUpdatePayload updateData);
    }
}