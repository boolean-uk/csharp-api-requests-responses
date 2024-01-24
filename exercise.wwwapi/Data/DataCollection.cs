using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class DataCollection
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public Student AddStudent(Student student)
        {
            _students.Add(student);
            return student;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }

        public Student GetSpecificStudent(string firstName) 
        {
            var student = _students.FirstOrDefault(x => x.FirstName == firstName);
            return student; 
        }

        public Student GetVerySpecificStudent(string firstName, string lastName) 
        {
            var student = _students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            return student;
        }

        public void RemoveStudent(Student student)
        {
            _students.Remove(student);
        }

        // ----------------------- Language ----------------------------

        private static List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public Language AddLanguage(Language language) 
        {
            languages.Add(language);
            return language;
        }

        public IEnumerable<Language> GetAllLanguages()
        {
            return languages;
        }

        public Language GetSpecificLanguage(string name)
        {
            var language = languages.FirstOrDefault(x => x.name == name); 
            return language;
        }

        public void RemoveLanguage(Language language)
        {
            languages.Remove(language); 
        }

        // ----------------- Book ---------------------

        private static List<Book> books = new List<Book>()
        {
            new Book() {Id = 1, Title = "A Game Of Thrones", Author = "George R. R. Martin", Genre = "Fantasy", NumPages = 760},
            new Book() {Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", NumPages = 336},
            new Book() {Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Classics", NumPages = 180},
            new Book() {Id = 4, Title = "1984", Author = "George Orwell", Genre = "Dystopian", NumPages = 328}
        };

        public Book AddBook(Book book)
        {
            int Id = books.Max(x => x.Id) + 1;
            book.Id = Id;
            books.Add(book);
            return book;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetSpecificBook(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            return book; 
        }

        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }
    }
}
