using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private LanguageCollection languages;

        public LanguageRepository(LanguageCollection languages)
        {
            this.languages = languages;
        }

        public List<Language> GetAllLang()
        {
            return languages.GetAll();
        }

        public Language AddLanguage(string name)
        {
            return languages.Add(name);
        }

        public Language? GetLanguage(int id)
        {
            return languages.Get(id);
        }

        public Language? UpdateLanguage(Language language, LanguageUpdatePayload updateData)
        {
            bool hasUpdate = false;

            if (updateData.name != null)
            {
                language.SetName((string)updateData.name);
                hasUpdate = true;
            }

            if (!hasUpdate) throw new Exception("No update data provided");

            return language;
        }

        public List<Language> DeleteLanguage(int id)
        {
            languages.Delete(id);
            return languages.GetAll();
        }
    }
}
