using exercise.wwwapi.Models;
namespace exercise.wwwapi.Repository
{
    //Interface
    public interface IlanguageRepository
    {
        public List<Language> GetLanguages(); 

        public Language GetLanguageByName(string name);

        public Language AddLanguage(string languageName);

        public Language UpdateLanguage(string languageName, LanguageItemUpdate updatedata);

        public Language DeleteLanguage(string languageName);
    }
}
