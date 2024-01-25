using exercise.wwwapi.Models;
using exercise.wwwapi.Data;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        /// <summary>
        /// Retrieve all <see cref="Student"/> objects contained within the <see cref="StudentCollection"/> object
        /// </summary>
        /// <returns>IEnumerable<Student> - Enumerable of each <see cref="Student"/> </returns>
        IEnumerable<Student> GetStudents();

        /// <summary>
        /// Retrieve a specific <see cref="Student"/> object from the <see cref="StudentCollection"/> based on the provided first name of the <see cref="Student"/>.
        /// </summary>
        /// <param name="firstName"> string - The first name of the student to retrieve from the collection </param>
        /// <returns> <see cref="Student"/> object that has the same first name as input param, null if not found </returns>
        Student GetStudentByFirstName(string firstName);

        /// <summary>
        /// Create a new <see cref="Student"/> object in the <see cref="StudentCollection"/>
        /// </summary>
        /// <param name="firstName">string - the first name of the new <see cref="Student"/> object</param>
        /// <param name="lastName">string - the last name of the new <see cref="Student"/> object</param>
        /// <returns><see cref="Student"/> - the created <see cref="Student"/> object</returns>
        Student PostStudent(string firstName, string lastName);

        /// <summary>
        /// Change a <see cref="Student"/> object first and last names, object identified by their original first name value
        /// </summary>
        /// <param name="firstName"> string - the existing first name of the object, if multiple matches only the first in the collection will be retrieved</param>
        /// <param name="newFirstName">string - the new first name of the <see cref="Student"/> object</param>
        /// <param name="newLastName">string - the new last name of the <see cref="Student"/> object</param>
        /// <returns> <see cref="Student"/> - the modified <see cref="Student"/> object, if the first name was not found returns null</returns>
        Student UpdateStudentByFirstName(string firstName, string newFirstName, string newLastName);

        /// <summary>
        /// Remove a <see cref="Student"/> object from the <see cref="StudentCollection"/>, <see cref="Student"/> object identified by their first name value
        /// </summary>
        /// <param name="firstName"> string - the first name of the <see cref="Student"/> object to retrieve, if multiple matches the first in the collection is selected </param>
        /// <returns><see cref="Student"/> - the <see cref="Student"/> object that was removed from the <see cref="StudentCollection"/></returns>
        Student DeleteStudentByFirstName(string firstName);

        /// <summary>
        /// Create a new Language object in the <see cref="LanguageCollection"/>.
        /// </summary>
        /// <param name="languageName">string - the name of the <see cref="Language"/></param>
        /// <returns> <see cref="Language"/> - the <see cref="Language"/> object added to the collection</returns>
        Language PostLanguage(string languageName);

        /// <summary>
        /// Retrieve all <see cref="Language"/> objects in the <see cref="LanguageCollection"/>.
        /// </summary>
        /// <returns>IEnumerable<Language> - Enumerable of each <see cref="Language"/> </returns>
        IEnumerable<Language> GetLanguages();

        /// <summary>
        /// Retrieve a specific <see cref="Language"/> from the <see cref="LanguageCollection"/> based on the objects name.
        /// </summary>
        /// <param name="languageName">string - the name of the <see cref="Language"/> to retrieve</param>
        /// <returns><see cref="Language"/> - a <see cref="Language"/> object from the <see cref="LanguageCollection"/>, null if not found</returns>
        Language GetSpecificLanguage(string languageName);

        /// <summary>
        /// Change a <see cref="Language"/> object name, object identified by their original name.
        /// </summary>
        /// <param name="languageName">string - the name of the <see cref="Language"/> to modify</param>
        /// <param name="newLanguageName">string - the new name of the <see cref="Language"/> object</param>
        /// <returns><see cref="Language"/> - The modified <see cref="Language"/> object, null if not found</returns>
        Language UpdateLanguageName(string languageName, string newLanguageName);

        /// <summary>
        /// Remove a <see cref="Language"/> object from the <see cref="LanguageCollection"/>, <see cref="Language"/> object are identified by their name.
        /// </summary>
        /// <param name="languageName">string - the name of the Language object to remove</param>
        /// <returns> Language - The Language object that was removed from the collection, null if no matching language objects found </returns>
        Language DeleteLanguage(string languageName);

        // EXTENSION

        /// <summary>
        /// Retrieve all <see cref="Book"/> contained within the <see cref="BookCollection"/>.
        /// </summary>
        /// <returns>IEnumerable<Book> - Enumerable of the <see cref="Book"/> objects</returns>
        IEnumerable<Book> GetAllBooks();

        /// <summary>
        /// Retrieve a specific <see cref="Book"/> from the <see cref="BookCollection"/> by its Id.
        /// </summary>
        /// <param name="id">int - the id of the <see cref="Book"/> object to retrieve</param>
        /// <returns><see cref="Book"/> - The <see cref="Book"/> object with the matching id, null if no book of the provided id found</returns>
        Book GetSpecificBook(int id);

        /// <summary>
        /// Create a new <see cref="Book"/> object and add it to the <see cref="BookCollection"/> by passing a temporary <see cref="BookDraft"/> to be transcribed into a <see cref="Book"/> object.
        /// </summary>
        /// <param name="newBook"> <see cref="BookDraft"/> - A draft class to transcribe </param>
        /// <returns> <see cref="Book"/> - the created book, null if <see cref="BookDraft"/> could not be transcribed</returns>
        Book AddNewBook(BookDraft newBook);

        /// <summary>
        /// Attempt to update the content of a <see cref="Book"/> object in the <see cref="BookCollection"/> by passing in the new information as a <see cref="BookDraft"/> item to be transcribed onto a Book object of a specific id.
        /// </summary>
        /// <param name="id"> int - the id of the Book in the <see cref="BookCollection"/> to modify</param>
        /// <param name="updatedBook"><see cref="BookDraft"/> - the temporary object to transcribe onto the <see cref="Book"/> object</param>
        /// <returns><see cref="Book"/> - the updated <see cref="Book"/> object in the <see cref="BookCollection"/>, null if no <see cref="Book"/> of provided id was found</returns>
        Book UpdateBook(int id, BookDraft updatedBook);

        /// <summary>
        /// Remove a <see cref="Book"/> object from the <see cref="BookCollection"/> based on the Book objects id.
        /// </summary>
        /// <param name="id"> int - the id of the Book object to be removed</param>
        /// 
        /// <returns><see cref="Book"/> - the <see cref="Book"/> object removed from the <see cref="BookCollection"/>, null if no Book of provided id found</returns>
        Book RemoveBook(int id);
    }
}
