using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private LanguageCollection _languages;

        public LanguageRepository(LanguageCollection languages)
        {
            _languages = languages;
        }
        public Language CreateALanguage(string name)
        {
            Language Language = new Language(name) ;
            _languages.Add(Language);

            return Language;
        }

        public Language DeleteALanguage(string name)
        {
            Language Language = GetALanguage(name);

            _languages.RemoveLanguage(Language);


            return Language;
        }

        public List<Language> GetAllLanguages()
        {
            return _languages.getAll();
        }

        public Language GetALanguage(string name)
        {
            Language Language = _languages.GetLanguage(name);

            if (Language == null)
            {
                return null;
            }
            return Language;
        }

        public Language UpdateALanguage(string name, LanguageUpdateData updateData)
        {
            Language Language = DeleteALanguage(name);

            Language.SetName(updateData.Name);
            

            _languages.Add(Language);

            return Language;
        }
    }
}
