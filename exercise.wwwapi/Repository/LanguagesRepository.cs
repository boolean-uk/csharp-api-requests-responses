
namespace exercise.wwwapi
{
    public class LanguagesRepository
    {
        private readonly LanguageCollection _languageCollection;

        public LanguagesRepository(LanguageCollection languageCollection)
        {
            _languageCollection = languageCollection;
        }

        public Language Add(Language language)
        {
            return _languageCollection.Add(language);
        }

        public List<Language> GetAll()
        {
            return _languageCollection.GetAll();
        }

        public Language Get(string name)
        {
            return _languageCollection.Get(name);
        }

        public Language Update(string oldName, string newName)
        {
            return _languageCollection.Update(oldName, newName);
        }

        public bool Delete(string name)
        {
            return _languageCollection.Delete(name);
        }
    }
}
