using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class DataCollection
    {
        private static List<Student> _students =
        [
            new Student("Nathan","King"),
            new Student("Dave", "Ames" )
        ];

        public Student AddStudent(Student student)
        {
            _students.Add(student);

            return student;
        }

        public Student DeleteStudent(string firstName)
        {
            Student stud = _students.Find(x => x.FirstName == firstName);
            if (stud != null)
            {
                _students.Remove(stud);
                return stud;
            }
            return null;
        }

        public List<Student> getAllStudents()
        {
            return _students.ToList();
        }

        private static List<Language> languages = new(){
            new Language("Java"),
            new Language("C#")
        };

        public List<Language> getLanguages()
        {
            return languages.ToList();
        }

        public Language CreateLanguage(string name)
        {
            Language language = new Language(name);
            languages.Add(language);
            return language;
        }

        public Language DeleteLanguage(string name)
        {
            Language lang = getLanguages().Find(x => x.name == name);
            languages.Remove(lang);
            return lang;
        }


        public List<Book> _books = new List<Book>()
        {
            new Book("Lord Of The Rings", 1000, "J.R.R Tolkien", "Fantasy"),
            new Book("Harry Potter", 459, "Bad Person", "Fantasy")
        };

        public Book CreateBook(Book book)
        {
            _books.Add(book);
            return book;
        }

        public List<Book> getAllBooks()
        {
            return _books.ToList();
        }

    }
}
