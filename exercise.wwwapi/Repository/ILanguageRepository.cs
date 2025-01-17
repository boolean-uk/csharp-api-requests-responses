using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        public Language Create(Language language);
        public Language Get(string name);
        public List<Language> GetAll();
        public Language Update(string name, Language language);
        public Language Delete(string name);

    }
}
