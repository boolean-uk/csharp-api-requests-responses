using exercise.wwwapi.Models;
using System.Collections.Generic;


namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        /* Method to get a collection of students
         This method  returns a sequence of Student objects*/
        IEnumerable<Student> GetStudents();

        /* Method to add a new student to the repository 
        This method takes a Student object as a parameter and returns the added student*/
        Student AddStudent(Student student);

        Student GetStudent(string firstName); // method for getting a single student
        Student UpdateStudent(string firstName, Student updatedStudent); // method for updating a student
        Student DeleteStudent(string firstName); // method for deleting a student


        /* 
        Method to get a collection of languages.
        This method returns a sequence of Language objects.*/

        IEnumerable<Language> GetLanguages();

        /* 
        Method to add a new language to the repository.
        This method takes a Language object as a parameter and returns the added language.
        */
        Language AddLanguage(Language language);
        Language GetLanguage(string name);
        Language UpdateLanguage(string name, Language updatedLanguage);
        Language DeleteLanguage(string name);


        /* 
        Method to get a collection of Books.
        This method returns a sequence of Book objects.*/
        IEnumerable<Book> GetBooks();
        Book AddBook(Book book);
        Book GetBook(int id);
        Book UpdateBook(int id, Book updatedBook);
        Book DeleteBook(int id);
    }
}


