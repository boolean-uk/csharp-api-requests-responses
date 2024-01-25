using exercise.wwwapi.Models;
using System.Runtime.CompilerServices;

namespace exercise.wwwapi.Data
{
    public class DataCollection
    {

        //Adding BooksList to collection
        private static List<Book> _books = new List<Book>()
        {
            new Book () {id = 1, title ="A Game of Thrones", numPages = 790, author ="George R. R. Martin", genre = "Fantasy"},
            new Book () {id = 2, title ="Harry Potter and The Chamber Of Secrets", numPages = 560, author ="J.K. Rowling", genre = "Fantasy"},
            new Book () {id = 3, title ="Harry Potter and The Prisoner of Azkaban", numPages = 690, author ="J.K. Rowling", genre = "Fantasy"},
        };

        //Collecting both Language and Student Lists together
        private static List<Language> _languages = new List<Language>(){
            new Language() { name = "Java"},
            new Language() { name = "C#" }
        };

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
            return _students.FirstOrDefault(s => s.FirstName.ToLower() == firstname.ToLower());
        }
        public Student DeleteStudent(string firstname)
        {
            var item = GetStudent(firstname);
            if (item != null) { _students.Remove(item); return item; }

            return null;
        }
        public Student UpdateStudent(string firstname, Student newStudent)
        {
            var existingStudent = GetStudent(firstname);

            if (existingStudent == null)
            {
                return null;
            }
            existingStudent.FirstName = !string.IsNullOrEmpty(newStudent.FirstName) ? newStudent.FirstName : existingStudent.FirstName;
            existingStudent.LastName = !string.IsNullOrEmpty(newStudent.LastName) ? newStudent.LastName : existingStudent.LastName;
            int index = _students.IndexOf(existingStudent);
            _students[index] = existingStudent;

            return existingStudent;
        }
        public List<Language> GetAllLanguages()
        {
            return _languages.ToList();
        }
        public Language GetOneLanguage(string name)
        {
            return _languages.FirstOrDefault(x => x.name.ToLower() == name.ToLower());
        }
        public Language UpdateLanguage(string name, Language newLanguage)
        {
            Language orgLang = GetOneLanguage(name);
            orgLang.name = newLanguage.name;
            int index = _languages.IndexOf(orgLang);
            _languages[index] = orgLang;

            return orgLang;
        }
        public Language DeleteLanguage(string name)
        {
            var item = GetOneLanguage(name);
            if (item != null) { _languages.Remove(item); return item; }

            return null;
        }
        public Language AddLanguage(Language language)
        {
            _languages.Add(language);
            return language;
        }

        public List<Book> GetAllBooks()
        {
            return _books.ToList();
        }

        public Book GetBook(int id)
        {
            return _books.FirstOrDefault(b => b.id == id);
        }

        public Book AddBook(InputBook book)
        {
            Book newBook = new Book() { id = _books.Max(x => x.id) + 1, author = book.author, genre = book.genre, numPages = book.numPages, title = book.title };
            _books.Add(newBook);
            return newBook;
        }

        public Book DeleteBook(int id)
        {
            var item = GetBook(id);
            if (item != null)
            {

                _books.Remove(item);
                return item;
            }

            return null;
        }

        public Book UpdateBook(int id, InputBook inputBook)
        {
            var existingBook = GetBook(id);
            if (existingBook == null)
            {
                return null;
            }
            existingBook.title = !string.IsNullOrEmpty(inputBook.title) ? inputBook.title : existingBook.title;
            existingBook.author = !string.IsNullOrEmpty(inputBook.author) ? inputBook.author : existingBook.author;
            existingBook.numPages = inputBook.numPages < 0 ? inputBook.numPages : existingBook.numPages;
            existingBook.genre = !string.IsNullOrEmpty(inputBook.genre) ? inputBook.genre : existingBook.genre;

            return existingBook;
        }
    }

}