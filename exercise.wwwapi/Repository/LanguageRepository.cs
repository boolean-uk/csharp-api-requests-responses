
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Models.Payload;


namespace exercise.wwwapi.Repository {

    public class LanguageRepository : ILanguageRepository
    {
        private LanguageCollection _languages;

        public LanguageRepository(LanguageCollection languages) {
            _languages = languages;
        }

        public Language AddLanguage(string Name)
        {
            Language language = new Language(Name);
            _languages.Add(language);
            return language;
        }

        public Language DeleteLanguage(string Name)
        {
            return _languages.Remove(Name);
        }

        public List<Language> GetAllLanguages()
        {
            return _languages.GetAll();
        }

        public Language GetLanguage(string Name)
        {
            return _languages.Get(Name);
        }

        public Language UpdateLanguage(string Name, LanguageUpdatePayload updateData)
        {
            var language = _languages.Get(Name);
            if (language == null)
            {
                return null;
            }

            bool hasUpdate = false;

            if(updateData.name != null)
            {
                language.Name = (string)updateData.name;
                hasUpdate = true;
            }

            if(!hasUpdate) throw new Exception("No update data provided");

            return language;
        }
    }
}