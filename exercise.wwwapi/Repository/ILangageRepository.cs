using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILangageRepository
    {
        Language CreateLanguage(Language language);
        List<Language> GetLanguages();
        Language GetLanguage(string name);
        Language Update(string name, Language language);
        public Language Delete(string name);
    }
}
