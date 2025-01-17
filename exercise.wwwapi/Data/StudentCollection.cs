using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class StudentCollection
    {
        private static List<Student> _students { get; set; } = new List<Student>();

        public static void Initialize()
        {
            _students.Add(new Student() { FirstName = "Nathan", LastName = "King" });
            _students.Add(new Student() { FirstName = "Dave", LastName = "Ames" });
        }

        public static Student Add(Student student)
        {            
            _students.Add(student);

            return student;
        }

        public static List<Student> GetAll()
        {
            return _students.ToList();
        }

        public static Student GetOne(string firstname)
        {
            return _students.Find(x => x.FirstName == firstname);
        }
        public static bool Delete(string firstname)
        {
            return _students.RemoveAll(x => x.FirstName == firstname) > 0 ? true : false;
        }
    }


}
