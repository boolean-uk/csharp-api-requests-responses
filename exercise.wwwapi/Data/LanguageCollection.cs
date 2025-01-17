using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>(){
            new Language() {Name="Java"},
            new Language() {Name="C#"}
        };

        public static Language Add(Language language)
        {
            _languages.Add(language);
            return language;
        }

        public static Language Get(string language)
        {
            return _languages.FirstOrDefault(s => s.Name == language);
        }

        public static bool Remove(string language)
        {
            return _languages.RemoveAll(s => s.Name == language) > 0 ? true : false;
        }

        public static Language Update(string name, Language entity)
        {
            Language language = Get(name);
            language.Name = entity.Name;
            return language;
        }

        public static List<Language> Languages { get { return _languages; } }
    }
}
