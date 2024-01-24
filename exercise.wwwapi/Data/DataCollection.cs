using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Xml.Linq;

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

        public List<Student> getAllStudents()
        {
            return _students.ToList();
        }

        public Student GetStudent(string firstname)
        {
            var student = _students.FirstOrDefault(student => student.FirstName == firstname);
            if (student != null)
            {
                return student;
            }
            return null;
        }

        public Student UpdateStudent(string firstname, Student newstudent)
        {
            var student = _students.FirstOrDefault(student => student.FirstName == firstname);
            if (student == null)
            {
                return null;
            }
            student.FirstName = newstudent.FirstName; 
            student.LastName = newstudent.LastName;
            return student;
        }

        public Student DeleteStudent(string firstname)
        {
            var student = _students.FirstOrDefault(student => student.FirstName == firstname);
            _students.RemoveAll(student => student.FirstName == firstname);
            return student;
        }


        private static List<Languages> languages = new List<Languages>(){
            new Languages() {name = "Java"},
            new Languages() {name = "C#"}
        };

        public Languages AddLanguage(Languages language)
        {
            languages.Add(language);

            return language;
        }

        public List<Languages> getAllLanguages()
        {
            return languages.ToList();
        }

        public Languages GetLanguage(string name)
        {
            var language = languages.FirstOrDefault(language => language.name == name);
            if (language == null)
            {
                return null;
            }
            return language;
        }

        public Languages UpdateLanguage(string name, Languages newLanguage)
        {
            var language = languages.FirstOrDefault(language => language.name == name);
            if (language == null)
            {
                return null;
            }
            language.name = newLanguage.name;
            language.name = newLanguage.name;
            return language;
        }

        public Languages DeleteLanguage(string name)
        {
            var language = languages.FirstOrDefault(language => language.name == name);
            languages.RemoveAll(language => language.name == name);
            return language;
        }

        private static List<Book> _books = new List<Book>()
        {
            new Book() { Id = 1, Title="The Hitchhiker's Guide to the Galaxy", NumPages = 216, Author = "Douglas Adams", Genre = "Science Fiction" },
            new Book() { Id = 2, Title="Eragon", NumPages = 503, Author = "Christopher Paolini", Genre = "Fantasy" }
        };

        public Book AddBook(InPuBook book)
        {
            Book newBook = new Book();
            newBook.Id = _books.Max(book => book.Id)+1;
            newBook.Title = book.Title;
            newBook.NumPages = book.NumPages;
            newBook.Author = book.Author;
            newBook.Genre = book.Genre;
            _books.Add(newBook);

            return newBook;
        }

        public List<Book> getAllBooks()
        {
            return _books.ToList();
        }

        public Book GetBook(int id)
        {
            var book = _books.FirstOrDefault(book => book.Id == id);
            if (book == null)
            {
                return null;
            }
            return book;
        }

        public Book UpdateBook(int id, InPuBook newBook)
        {
            var book = _books.FirstOrDefault(book => book.Id == id);
            if (book == null)
            {
                return null;
            }
            book.Title = newBook.Title;
            book.NumPages = newBook.NumPages;
            book.Author = newBook.Author;
            book.Genre = newBook.Genre;
            return book;
        }

        public Book DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(book => book.Id == id);
            _books.RemoveAll(book => book.Id == id);
            return book;
        }
    }
}
