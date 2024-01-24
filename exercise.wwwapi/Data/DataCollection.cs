using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Xml.Linq;

namespace exercise.wwwapi.Data
{
    public class DataCollection
    {
        private static List<Language> _languages = new List<Language>(){
            new Language() { name = "Java"},
            new Language() { name = "C#" }
        };

        private static List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        private static List<Book> _books = new List<Book>()
        {
            new Book() {id = 1, title = "A Game Of Thrones", author = "George R. R. Martin", genre = "Fantasy", numPages = 760},
            new Book() {id = 2, title = "To Kill a Mockingbird", author = "Harper Lee", genre = "Fiction", numPages = 336},
            new Book() {id = 3, title = "The Great Gatsby", author = "F. Scott Fitzgerald", genre = "Classics", numPages = 180},
            new Book() {id = 4, title = "1984", author = "George Orwell", genre = "Dystopian", numPages = 328}
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
        public Student GetOneStudent(string firstname)
        {
            return _students.FirstOrDefault(s=>s.FirstName.ToLower()==firstname.ToLower());
        }
        public Student DeleteStudent(string firstname)
        {
            var item = GetOneStudent(firstname);
            if (item != null) { _students.Remove(item); return item; }

            return null;
        }
        public Student UpdateStudent(string firstname, Student newStudent)
        {
            var existingStudent = GetOneStudent(firstname);

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
            return _languages.FirstOrDefault(x=>x.name.ToLower() == name.ToLower());
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
        public Book GetOneBook(int id)
        {
            return _books.FirstOrDefault(b => b.id == id);
        }
        public Book UpdateBook(int id, InputBook inputBook)
        {
            var existingBook = GetOneBook(id);
            

            if (existingBook == null)
            {
                return null;
            }
            existingBook.title = !string.IsNullOrEmpty(inputBook.title) ? inputBook.title : existingBook.title;
            existingBook.author = !string.IsNullOrEmpty(inputBook.author) ? inputBook.author: existingBook.author;
            existingBook.numPages = inputBook.numPages < 0 ? inputBook.numPages : existingBook.numPages;
            existingBook.genre = !string.IsNullOrEmpty(inputBook.genre) ? inputBook.genre : existingBook.genre;
            int index = _books.IndexOf(existingBook);
            _books[index] = existingBook;

            return existingBook;
        }
        public Book DeleteBook(int id)
        {
            var item = GetOneBook(id);
            if (item != null) { _books.Remove(item); return item; }

            return null;
        }
        public Book AddBook(InputBook book)
        {
            Book newBook = new Book() {id = _books.Max(x=>x.id)+1, author = book.author, genre = book.genre, numPages = book.numPages, title = book.title };
            _books.Add(newBook);
            return newBook;
        }
    }

}
