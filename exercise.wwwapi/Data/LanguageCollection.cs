using exercise.wwwapi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public Language Add(LanguagePostPayload data)
        {
            Language newLanguage = new Language(data.name);
            languages.Add(newLanguage);
            return newLanguage;
        }
        public List<Language> GetAll()
        {
            return languages;
        }
        public Language? Get(string language)
        {
            Language? result = languages.Find(x => x.name == language);
            return result;
        }

        public Language Change(string language, LanguagePostPayload data)
        {
            Language? result = languages.Find(x => x.name == language);
            if (result is null) throw new Exception();
            result.name = data.name;
            return result;
        }

        public Language Delete(string language)
        {
            Language? result = languages.Find(x => x.name == language);
            if (result is null) throw new Exception();
            languages.Remove(result);
            return result;
        }
    }
}
