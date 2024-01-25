
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository2
    {
        IEnumerable<Language> GetLanguages();
        Language AddLanguage(Language language);
        Language UpdateLanguage(int id, LanguagePut languagePut);
        bool DeleteLanguage(int id);

    }
}


