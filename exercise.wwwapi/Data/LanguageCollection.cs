using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> _languages { get; set; } = new List<Language>();

        public static void Initialize()
        {
            _languages.Add(new Language { name = "Java" });
            _languages.Add(new Language { name = "C#" });
        }

        public static Language Get(string name)
        {
            return _languages.FirstOrDefault(x => x.name == name);
        }
        public static Language Add(Language entity)
        {
            _languages.Add(entity);
            return entity;
        }
        public static bool Remove(string name)
        {
            _languages.RemoveAll(x => x.name == name);
            return true;
        }
        //public static Language Update(Language entity)
        //{
          //  _languages.U
        //}

        public static List<Language> Languages { get { return _languages; } }
    }
}
