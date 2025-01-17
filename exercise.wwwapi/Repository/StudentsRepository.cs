
namespace exercise.wwwapi
{
    public class StudentsRepository
    {
        private readonly StudentCollection _studentCollection;

        public StudentsRepository(StudentCollection studentCollection)
        {
            _studentCollection = studentCollection;
        }

        public Student Add(Student student)
        {
            return _studentCollection.Add(student);
        }

        public List<Student> GetAll()
        {
            return _studentCollection.GetAll();
        }

        public Student Get(string firstName)
        {
            return _studentCollection.Get(firstName);
        }

        public Student Update(string firstName, string newFirstName, string newLastName)
        {
            var student = _studentCollection.Get(firstName);

            if (student == null)
            {
                return null;
            }

            return _studentCollection.Update(firstName, newFirstName, newLastName);
        }

        public bool Delete(string firstName)
        {
            return _studentCollection.Delete(firstName);
        }

    }
}
