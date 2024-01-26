using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class DataCollection
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student(){ Id = 1,  FirstName="Adam", LastName= "Gården"},
            new Student(){ Id = 2,  FirstName="Gordon", LastName= "Ramsy"},
        };


        // add or create a student
        public Student AddStudent(Student student)
        {
            _students.Add(student);
            return student;
        }


        // get all the students
        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

        // get a student
        public bool GetStudent(int id, out Student student)
        {
            student = _students.FirstOrDefault(student => student.Id == id);

            if (student == null)
            {
                return false;
            }

            return true;
        }


        // update a student
        public Student UpdateStudent(int id, StudentPut student)
        {
            var target = _students.FirstOrDefault(student => student.Id == id);
            target.FirstName = student.FirstName;
            target.LastName = student.LastName;
            return target;
        }

        // delete a student
        public bool DeleteStudent(int id)
        {
            var index = _students.FindIndex(student => student.Id == id);
            if (index == -1)
                return false;

            _students.RemoveAt(index);
            return true;
        }



        //********************************************************************
        private List<Language> _languages = new List<Language>(){
            new(){ Id = 1, Name = "Java"},
            new(){ Id = 2, Name =  "C#"}
        };


        public Language AddLanguage(Language language)
        {
            _languages.Add(language);
            return language;
        }

        public bool DeleteLanguage(int id)
        {

            var languageToRemove = _languages.FirstOrDefault(s => s.Id == id);
            if (languageToRemove != null)
            {
                _languages.Remove(languageToRemove);
                return true;
            }
            return false;
        }

        public bool GetLanguage(int id, out Language language)
        {
            language = _languages.FirstOrDefault(language => language.Id == id);
            if (language == null)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _languages;
        }


        public Language UpdateLanguage(int id, LanguagePut language)
        {
            var target = _languages.FirstOrDefault(language => language.Id == id);
            target.Name = language.Name;
            return target;
        }


        //***************************************************************************


        private List<Book> _books = new List<Book>(){
            new(){ Id = 1, Title = "Java", Author = "Kevin",nunmPages = 100, Gnre = "Programming"},
            new(){ Id = 1, Title = "C#", Author = "Ole",nunmPages = 200, Gnre = "Programming"},
        };


        public Book AddBook(Book book)
        {
            _books.Add(book);
            return book;
        }

        public bool DeleteBook(int id)
        {

            var bookToRemove = _books.FirstOrDefault(s => s.Id == id);
            if (bookToRemove != null)
            {
                _books.Remove(bookToRemove);
                return true;
            }
            return false;
        }

        public bool GetBook(int id, out Book book)
        {
            book = _books.FirstOrDefault(book => book.Id == id);
            if (book == null)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _books;
        }


        public Book UpdateBook(int id, BookPut book)
        {
            var target = _books.FirstOrDefault(book => book.Id == id);
            target.Author = book.Author;
            target.Title = book.Title;
            target.nunmPages = book.numPages;
            target.Gnre = book.Gnre;
            return target;
        }


    }
}