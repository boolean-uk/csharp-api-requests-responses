using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        void AddLanguage(Language language);
        IEnumerable<Language> GetAllLanguages();
        Language GetLanguageByName(string name);
        Language UpdateLanguageInfo(string old, string newName);
        Language DeleteLanguage(string name);
    }
}
