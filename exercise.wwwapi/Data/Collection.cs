using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class Collection : ICollection
    {
        private static List<Language> _languages = new List<Language>()
        {
                new Language() { Name="Java" },
                new Language() { Name="C#" }
        };

        private static List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        private static List<Book> _books = new List<Book>()
        {
            new Book() { Id=0, Title="Harry Potter", NumPages=354, Author="J.K. Rowling", Genre="Fantasy"},
            new Book() { Id=1, Title="A Song of Ice and Fire", NumPages=652, Author="George R. R. Martin", Genre="Fantasy" }
        };

        public IEnumerable<Student> GetStudents()
        {
            return _students.ToList();
        }

        public Student GetStudent(string name)
        {
            return _students.FirstOrDefault(student => student.FirstName == name);
        }

        public Student AddStudent(Student student)
        {
            _students.Add(student);
            return student;
        }

        public Student UpdateStudentName(string name, Student student)
        {
            var updateStudent = _students.FirstOrDefault(s => s.FirstName == name);

            if (updateStudent == null)
            {
                return null;
            }

            updateStudent.FirstName = student.FirstName;
            updateStudent.LastName = student.LastName;

            return updateStudent;
        }

        public Student DeleteStudent(string name)
        {
            var deletedStudent = _students.FirstOrDefault(student => student.FirstName == name);

            if (deletedStudent == null)
            {
                return null;
            }

            _students.Remove(deletedStudent);
            return deletedStudent;
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _languages.ToList();
        }

        public Language GetLanguage(string name)
        {
            return _languages.FirstOrDefault(language => language.Name == name);
        }

        public Language AddLanguage(string name)
        {
            Language language = new Language() { Name = name };
            _languages.Add(language);
            return language;
        }

        public Language UpdateLanguage(string oldName, string newName)
        {
            var language = _languages.FirstOrDefault(lang => lang.Name == oldName);

            if (language == null)
            {
                return null;
            }

            language.Name = newName;
            return language;
        }

        public Language DeleteLanguage(string name)
        {
            var language = _languages.FirstOrDefault(lang => lang.Name == name);

            if (language == null)
            {
                return null;
            }

            _languages.Remove(language);
            return language;
        }

        public Book AddBook(BookPost book)
        {
            int id = _books.Max(book => book.Id) + 1;
            Book newBook = new Book() { Id=id, Title = book.Title, NumPages=book.NumPages, Author=book.Author, Genre=book.Genre };
            _books.Add(newBook);
            return newBook;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _books.ToList();
        }

        public Book GetBook(int id)
        {
            return _books.FirstOrDefault(book => book.Id == id);
        }

        public Book UpdateBook(int id, BookPost book)
        {
            var updateBook = _books.FirstOrDefault(b => b.Id == id);

            if (updateBook == null)
            {
                return null;
            }

            updateBook.Title = book.Title;
            updateBook.NumPages = book.NumPages;
            updateBook.Author = book.Author;
            updateBook.Genre = book.Genre;

            return updateBook;
        }

        public Book DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(book => id == book.Id);

            if (book == null) 
            {
                return null;
            }

            _books.Remove(book);
            return book;
        }
    }
}
