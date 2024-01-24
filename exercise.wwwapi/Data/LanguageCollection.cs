using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> _languages = new List<Language>(){
            new Language() {Name = "Java"},
            new Language() {Name = "C#"},
        };

        public Language Add(Language language)
        {
            _languages.Add(language);

            return language;
        }

        public List<Language> getAll()
        {
            return _languages.ToList();
        }

        public Language Get(string name)
        {
            return _languages.FirstOrDefault(x => x.Name == name);
        }

        public Language Update(string name, Language language)
        {
            Language l = new();
            l = _languages.FirstOrDefault(x => x.Name == name);
            l.Name = language.Name;
            return l;
        }

        public void Delete(string name)
        {
            _languages.Remove(_languages.FirstOrDefault(x => x.Name == name));
        }
    }
}
