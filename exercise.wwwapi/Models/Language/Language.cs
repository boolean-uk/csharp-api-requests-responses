namespace exercise.wwwapi.Models.Language
{
    public class Language
    {
        public string Name { get; private set; }

        public Language(string name)
        {
            this.Name = name;
        }

        public string getName() { return Name; }


        public string updateName(string newName)
        {
            Name = newName;
            return Name;
        }
    }
}
