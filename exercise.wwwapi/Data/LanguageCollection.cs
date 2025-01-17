using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };


        public Language Add(Language language)
        {

            languages.Add(language);

            return language;
        }
        public Language Delete(string name)
        {
            var deletedlanguage = languages.FirstOrDefault(x => x.name == name);
            if (deletedlanguage != null) { languages.Remove(deletedlanguage); }

            return deletedlanguage;
        }

        public Language GetLanguage(string name)
        {
            var language = languages.FirstOrDefault(x => x.name == name);
            return language;


        }
        public Language UpdateLanguage(string oldName, string newName)
        {
            var language = languages.FirstOrDefault(x => x.name == oldName);
            if (language == null)
            {
                throw new Exception($"No language found with name {oldName}");
            }
            language.name = newName;
            return language;


        }

        public List<Language> getAll()
        {
            return languages.ToList();
        }
    };
}

