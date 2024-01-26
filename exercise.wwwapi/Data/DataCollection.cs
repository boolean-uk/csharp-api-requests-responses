using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class DataCollection
    {
        private List<Language> _languages = new List<Language>(){
            new Language() {Name="Java"},
            new Language() {Name="C#"}
        };

        public IEnumerable<Language> GetLanguages()
        {
            return _languages.ToList();
        }

        public Language AddLanguage(Language language)
        {
            _languages.Add(language);
            return language;
        }

        public Language GetLanguage(string name)
        {
            return _languages.FirstOrDefault(x => x.Name == name);
        }

        public Language UpdateLanguage(string name, Language updatedLanguage)
        {
            var existingLanguage = _languages.FirstOrDefault(x => x.Name == name);

            if (existingLanguage != null)
            {
                existingLanguage.Name = updatedLanguage.Name;
                return existingLanguage;
            }

            return null; // Language not found
        }

        public Language DeleteLanguage(string name)
        {
            var languageToRemove = _languages.FirstOrDefault(x => x.Name == name);

            if (languageToRemove != null)
            {
                _languages.Remove(languageToRemove);
                return languageToRemove;
            }

            return null; // Language not found
        }


        /*--------------------------Student------------------------------------------*/
        private List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public IEnumerable<Student> GetStudents()
        {
            return _students.ToList();
        }

        public Student GetStudent(string firstName)
        {
            return _students.FirstOrDefault(s => s.FirstName.ToLower() == firstName.ToLower());
        }

        public Student UpdateStudent(string firstName, Student updatedStudent)
        {
            var existingStudent = GetStudent(firstName);

            if (existingStudent == null)
            {
                return null; // Student with the provided first name not found
            }

            // Update the details of the existing student
            existingStudent.FirstName = updatedStudent.FirstName;
            existingStudent.LastName = updatedStudent.LastName;

            return existingStudent;
        }

        public Student DeleteStudent(string firstName)
        {
            var studentToRemove = GetStudent(firstName);

            if (studentToRemove == null)
            {
                return null; // Student with the provided first name not found
            }

            // Remove the student from the list
            _students.Remove(studentToRemove);

            return studentToRemove;
        }

        public Student AddStudent(Student student)
        {
            _students.Add(student);

            return student;
        }

        /*--------------------------------------------------------------------Book--------------------------------------------------------------------------*/
        private List<Book> _books = new List<Book>()
        {
            new Book() { Id=1, Title="A Game of Thrones", NumPages=780, Author="George R.R. Martin", Genre="Fantasy" },
            new Book() { Id=2, Title="The Bible", NumPages=1444, Author="Multiple Unknowns", Genre="Religious" }
        };

        // Returns all books in the collection
        public IEnumerable<Book> GetBooks()
        {
            return _books.ToList();
        }

        // Adds a new book to the collection
        public Book AddBook(Book book)
        {
            _books.Add(book);
            return book;
        }

        // Method to get a single book by ID.
        public Book GetBook(int id)
        {
            return _books.FirstOrDefault(book => book.Id == id);
        }

        // Updates book details by its ID
        public Book UpdateBook(int id, Book updatedBook)
        {
            var existingBook = _books.FirstOrDefault(book => book.Id == id);

            if (existingBook != null)
            {
                existingBook.Title = updatedBook.Title == "string" ? existingBook.Title : updatedBook.Title;
                existingBook.NumPages = updatedBook.NumPages == 0 ? existingBook.NumPages : updatedBook.NumPages;
                existingBook.Author = updatedBook.Author == "string" ? existingBook.Author : updatedBook.Author; ;
                existingBook.Genre = updatedBook.Genre == "string" ? existingBook.Genre : updatedBook.Genre; ;

                return existingBook;  // Return the updated book
            }

            return null;
        }

        // Deletes a book by its ID
        public Book DeleteBook(int id)
        {
            var bookToRemove = _books.FirstOrDefault(book => book.Id == id);

            if (bookToRemove != null)
            {
                _books.Remove(bookToRemove);
            }

            return bookToRemove;
        }

    }

}
