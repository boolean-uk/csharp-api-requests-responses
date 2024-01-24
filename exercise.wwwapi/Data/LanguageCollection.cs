using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Languages> languages = new List<Languages>(){
            new Languages() {name = "Java"},
            new Languages() {name = "C#"}
        };
    }
}
