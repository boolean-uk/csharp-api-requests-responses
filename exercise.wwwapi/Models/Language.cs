namespace exercise.wwwapi.Models;

public class Language
{
    private string name {get; set;}

    public Language(string name)
    {
        this.name = name;
    }

    public string Name { get { return name; } set { name = value; } }
}
