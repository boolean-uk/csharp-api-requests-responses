using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private static List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public static Language Add(Language language)
        {
            languages.Add(language);
            return language;
        }

        public static Language Delete(string language)
        {
            Language languageToDelete = Get(language);
            languages.Remove(languageToDelete);
            return languageToDelete;
        }

        public static Language Get(string language)
        {
            return languages.FirstOrDefault(x => x.name == language);
        }

        public static IEnumerable<Language> GetAll()
        {
            return languages.ToList();
        }

        public static Language Update(string languageToUpdate, Language updatedLangauge)
        {
            Language l = Get(languageToUpdate);
            l = updatedLangauge;
            return l;

        }
    }
}
