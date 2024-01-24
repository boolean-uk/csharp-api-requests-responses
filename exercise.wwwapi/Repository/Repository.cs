using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataCollection _dataCollection = new DataCollection();

        public Repository(DataCollection dataCollection) {
            _dataCollection = dataCollection;
        }


        public IEnumerable<Student> getStudentCollections()
        {
            return _dataCollection.getAllStudents();
        }

        public IEnumerable<Language> getLanguageCollections()
        {
            return _dataCollection.getLanguages();
        }

        public IEnumerable<Student> getStudent(string firstName)
        {
            return _dataCollection.getAllStudents().Where(x=> x.FirstName == firstName);
        }

        public Student addStudent(string firstName, string lastName)
        {
            return _dataCollection.AddStudent(new Student(firstName, lastName));
        }

        public Student updateStudent(string firstName, string newFirstName, string newLastName)
        {
            Student temp = _dataCollection.getAllStudents().FirstOrDefault(x=>x.FirstName == firstName);
            temp.FirstName = newFirstName; temp.LastName = newLastName;
            return temp;
        }

        public Student deleteStudent(string firstName)
        {
            return _dataCollection.DeleteStudent(firstName);
        }
    }
}
