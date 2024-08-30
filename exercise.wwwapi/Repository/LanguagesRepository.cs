using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguagesRepository : ILanguagesRepository
    {
        public List<Language> GetAllLanguages()
        {
            return LanguageCollection.Languages;
        }

        public Language GetALanguage(string name)
        {
            return LanguageCollection.Languages.FirstOrDefault(x => x.Name.Equals(name));  
        }

        public Language AddLanguage(string name)
        {

            //I know the set ID method is not a good implementation, just need somethig simple that works
            return LanguageCollection.AddLanguage(new Language(name));
        }

        public Language UppdageLanguage(string name, string newName)
        {

            return LanguageCollection.UppdateLanguage(name, newName);
        }

        public Language RemoveLanguage(string name)
        {
            Language s = LanguageCollection.Languages.FirstOrDefault(x => x.Name.Equals(name));
            return LanguageCollection.removeLanguage(s);
        }
    }
}
