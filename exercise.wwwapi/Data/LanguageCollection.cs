using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public Language Add(string name)
        {
            languages.Add(new Language(name));
            return languages.Last();
        }

        public List<Language> GetAll()
        {
            return languages.ToList();
        }

        public Language? Get(int id)
        {
            return languages[id];
        }

        public void Delete(int id)
        {
            languages.RemoveAt(id);
        }
    }
}
