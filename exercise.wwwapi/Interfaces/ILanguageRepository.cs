using exercise.wwwapi.Models;

namespace exercise.wwwapi.Interfaces
{
    public interface ILanguageRepository
    {
        public Language AddLanguage(Language language);

        public List<Language> GetAllLanguages();

        public Language GetALanguage(string name);

        public Language UpdateLanguaget(string name, Language languageValue);

        public void DeleteLanguage(string name);
    }
}
