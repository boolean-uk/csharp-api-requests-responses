using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository2
    {
        
        void AddLanguage(Language language);
        List<Language> GetAllLanguages();
        Language GetLanguage(string name);
        Language UpdateLanguage(string old, string newName);
        Language DeleteLanguage(string name);
    }
}

