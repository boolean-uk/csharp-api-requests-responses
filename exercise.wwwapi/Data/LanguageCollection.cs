using exercise.wwwapi.Models;

namespace exercise.wwwapi
{

    public static class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>()
        {
            new Language() { Name="Java" },
            new Language() { Name="C#"}
        };

        public static Language AddLanguage(Language language)
        {
            _languages.Add(language);

            return language;
        }

        public static List<Language> GetAllLanguages()
        {
            return _languages.ToList();
        }

        public static Language GetLanguage(string name)

        {

            return _languages.FirstOrDefault(x => x.Name == name);

        }

        public static Language UpdateLanguage(string name, string newName)

        {
            Language language = GetLanguage(name);
            if (language != null)
            {
                language.Name = newName;
                return language;

            }

            return null;
        }

        public static Language DeleteLanguage(string name)

        {
            Language language;
            foreach (var lan in _languages)

            {
                if (!lan.Name.Equals(name))
                {
                    language = lan;
                    _languages.Remove(lan);



                    return language;

                }

            }

            return null;


        }

    }

}



