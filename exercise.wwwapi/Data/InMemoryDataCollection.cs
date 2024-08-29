using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class InMemoryDataCollection
    {
        
            public static List<Student> Students = new List<Student>
    {
                new Student { FirstName = "John",LastName = "Doe"},
                new Student { FirstName = "Mike",LastName = "Smith"},
                new Student { FirstName = "Alan",LastName = "Wake"},
        
    };

            public static List<Book> Books = new List<Book>
    {
                new Book { title = "C# in Depth", author = "Jon Skeet", genre="Education",numPages=244 },
                new Book { title = "Clean Code", author = "Robert C. Martin", genre = "Education", numPages=501 },
                new Book { title = "The Pragmatic Programmer", author = "Andrew Hunt", genre="Education", numPages=310 }
    };

            public static List<Language> Languages = new List<Language>
    {
                new Language { name = "English" },
                new Language { name = "French" },
                new Language { name = "Spanish" }
    };
        }
    }

