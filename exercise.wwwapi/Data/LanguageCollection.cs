using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection : IDatabase<Language>
    {
        private List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public IEnumerable<Language> Data { get { return languages; } set { languages = (List<Language>)value; } }
    }
}
