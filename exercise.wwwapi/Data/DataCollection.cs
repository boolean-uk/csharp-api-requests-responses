using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class DataCollection 
    {
        
        public static List<Student> students = new List<Student>()
        {
        new Student() { FirstName="Nathan",LastName="King" },
        new Student() { FirstName="Dave", LastName="Ames" }
        };

        public Student AddStudent(Student student)
        {
            students.Add(student);

            return student;
        }

        public IEnumerable<Student> GetStudents()
        {
            return students.ToList();
        }

        public Student UpdateStudent(string firstName, StudentPut studentPut)
        {
            var student = students.FirstOrDefault(s => s.FirstName == firstName);
            student.FirstName = studentPut.FirstName;
            student.LastName = studentPut.LastName;
            return student;
        }

        public Student GetStudentByFirstName(string firstName)
        {
            var student = students.FirstOrDefault(s => s.FirstName == firstName);
            if (student == null)
            {
                return null;
            }
            else return student;
        }

        public Student DeleteStudent(string firstName)
        {
            var student = students.FirstOrDefault(s => s.FirstName.Equals(firstName));
            students.Remove(student);
            return student;
        }

        public static List<Language> languages = new List<Language>()
        {
            new Language{ name = "C#" },
            new Language{ name = "Java"}
        };

        public IEnumerable<Language> GetLanguages()
        {
            return languages;
        }
        public Language AddLanguage(Language language)
        {
            languages.Add(language);
            return language;
        }

        public Language UpdateLanguage(string name, LanguagePut languagePut)
        {
            var language = languages.FirstOrDefault(l => l.name == name);
            language.name = languagePut.Name;
            return language;
        }
        public Language GetLanguageByName(string name)
        {
            var language = languages.FirstOrDefault(l => l.name == name);
            if (language == null)
            {
                return null;
            }
            else return language;
        }

        public Language DeleteLanguage(string name)
        {
            var language = languages.FirstOrDefault(l => l.name.Equals(name));
            languages.Remove(language);
            return language;
        }

        public static List<Book> books = new List<Book>()
        {
            new Book() {id = 1, title = "A Game Of Thrones", author = "George R. R. Martin", genre = "Fantasy", numPages = 780},
            new Book() {id = 2, title = "The Fellowship of the Ring", author = "J R. R. Tolkien", genre = "Fantasy", numPages = 423 },
            new Book() {id = 3, title = "Harry Potter and the Philosopher's stone", author = "J.K Rowling", genre = "Fantasy", numPages = 233 }
        };

        public Book AddBook(BookPost book)
        {
            Book newBook = new Book() { id = books.Max(x => x.id) + 1, author = book.author, genre = book.genre, numPages = book.numPages, title = book.title };
            books.Add(newBook);
            return newBook;
        }

        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            var book = books.FirstOrDefault(b => b.id == id);
            return book;
        }

        public Book UpdateBook(int id, BookPut bookPut)
        {
            var book = books.FirstOrDefault(b => b.id == id);
            book.title = bookPut.title == "string" ? book.title : bookPut.title;
            book.author = bookPut.author == "string" ? book.author : bookPut.author;
            book.genre = bookPut.genre == "string" ? book.genre : bookPut.genre;
            book.numPages = bookPut.numPages == 0 ? book.numPages : bookPut.numPages;
            return book;
        }

        public Book DeleteBookById(int id)
        {
            var book = books.FirstOrDefault(b => b.id == id);
            books.Remove(book);
            return book;
        }
    };

}
