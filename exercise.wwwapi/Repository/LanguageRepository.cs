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

        public List<Language> GetAllLanguages() 
        {
            return _languages.GetAllLanguages();
        }

        public Language AddLanguage(string name)
        {
            return _languages.AddLanguage(name);
        }

        public Language? GetLanguage(string name) 
        {
            Language lg = _languages.GetLanguage(name);

            if (lg == null) 
            {
                throw new Exception("Language not found!");
            }
            return lg;
        }

        public Language? DeleteLanguage(string name)
        {
            Language lg = _languages.DeleteLanguage(name);

            if (lg == null)
            {
                throw new Exception("Language not found!");
            }

            
            return lg;
        }

        public Language? UpdateLanguage(string name, LanguageUpdatePayload updateData)
        {
            var lg = _languages.GetLanguage(name);

            if(lg == null) 
            {
                return null;
            }

            bool hasName = false;

            if(updateData.name.Length > 0) 
            { 
                lg.name = (string)updateData.name;
                hasName = true;
            }

            if(!hasName)
            {
                throw new Exception("Update needs a name provided!");
            }

            return lg;
        }
    }
}
