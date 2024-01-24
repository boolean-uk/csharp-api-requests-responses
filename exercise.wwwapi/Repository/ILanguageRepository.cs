using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        public List<Language> getAll();

        public Language Add(Language language);

        public Language getALanguage(string langaugename);

        public Language updateLanguage(string langaugenamem, string newName);

        public Language deleteLanguage(string langaugename);
    }
}