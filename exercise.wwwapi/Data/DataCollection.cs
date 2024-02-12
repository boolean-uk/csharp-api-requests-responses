using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class DataCollection
    {

        private List<Language> _languages = new List<Language>(){
            new Language(){Name="Java" },
            new Language(){Name="C#"}
        };

        public Language AddLanguage(Language language)
        {
            _languages.Add(language);
            return language;
        }

        public List<Language> GetAllLanguages()
        {
            return _languages.ToList();
        }

        public Language GetLanguage(string name)
        {
            return _languages.Where(lang => lang.Name.Equals(name)).FirstOrDefault();
        }

        public Language UpdateLanguage(string name, Language language)
        {
            var updating = _languages.FirstOrDefault(lang => lang.Equals(language));
            language.Name = name;
            return updating;
        }

        public Language DeleteLanguage(string name)
        {
            var language = _languages.FirstOrDefault(lang => lang.Name.Equals(name));
            _languages.Remove(language);
            return language;
        }

        private List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public Student AddStudent(Student student)
        {            
            _students.Add(student);

            return student;
        }

        public List<Student> GetAllStudents()
        {
            return _students.ToList();
        }

        public Student GetStudent(string firstName)
        {
            return _students.FirstOrDefault(s => s.FirstName == firstName);
        }

        public Student UpdateStudent(string firstName, Student student)
        {
            var updating = _students.FirstOrDefault(s => s.FirstName.Equals(student));
            student.FirstName = firstName;
            return updating;
        }

        public Student DeleteStudent(string firstName)
        {
            var removing = _students.FirstOrDefault(s => s.FirstName.Equals(firstName));
            _students.Remove(removing);
            return removing;
        }

        private List<Book> _books = new List<Book>()
        {
            new Book() {Id = 1, Title = "Harry Potter", NumPages = 240, Author = "JK Rowling", Genre = "Fantasy"},
            new Book() {Id = 2, Title = "Diary of a Wimpy Kid", NumPages = 150, Author = "Jeff Kinney", Genre = "Comedy"}
        };
        public Book AddBook(Book book)
        {
            var newId = _books.Count + 1;
            Book newBook = new Book()
            {
                Id = newId,
                Title = book.Title,
                NumPages = book.NumPages,
                Author = book.Author,
                Genre = book.Genre
            };
            _books.Add(newBook);
            return newBook;
        }

        public List<Book> GetAllBooks()
        {
            return _books.ToList();
        }

        public Book GetBook(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public Book UpdateBook(int id, Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id.Equals(id));
            Book updatedBook = new Book()
            {
                Id = book.Id,
                Title = book.Title,
                NumPages = book.NumPages,
                Author = book.Author,
                Genre = book.Genre
            };

            existingBook = updatedBook;
            return existingBook;
        }

        public Book DeleteBook(int id)
        {
            var removing = _books.FirstOrDefault(b => b.Id.Equals(id));
            _books.Remove(removing);
            return removing;
        }

    };


}
