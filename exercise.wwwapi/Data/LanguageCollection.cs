using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private static List<Language> languages = new List<Language>(){
            new Language(){Name = "Java", Id = 1},
            new Language(){Name = "C#", Id = 2},
        };
    

    public static Language Add(Language language)
        {
            language.Id = languages.Max(x =>  x.Id) + 1;
            languages.Add(language);
            return language;
        }

    public static List<Language> getAll()
        {
            return languages.ToList();
        }

    public static Language GetById(int id)
        {
            return languages.Where(x => x.Id == id).FirstOrDefault();
        }
    public static bool Remove(int id)
        {
            return languages.Remove(GetById(id));
        }

    public static void Update(Language language)
        {
            languages.Where(x => x.Id == language.Id).FirstOrDefault().Name = language.Name;
        }
    }
}
