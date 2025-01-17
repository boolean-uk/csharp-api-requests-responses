using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class StudentCollection
    {
        public static List<Student> _students {  get; set; } = new List<Student>();

        public static void Initialize()
        {
            _students.Add(new Student { FirstName = "Nathan", LastName = "King" });
            _students.Add(new Student { FirstName = "Dave", LastName = "Ames" });
        }

        public static Student Get(string LastName)
        {
            return _students.FirstOrDefault(x => x.LastName == LastName);
        }
        public static Student Add(Student entity)
        {
            _students.Add(entity);
            return entity;
        }
        public static bool Remove(string LastName)
        {
            _students.RemoveAll(x => x.LastName == LastName);
            return true;
        }
        public static Student Update(string LastName, Student entity)
        {

            var student = _students.FirstOrDefault(x => x.LastName == LastName);
            if (student != null)
            {
                student.LastName = entity.LastName;
                student.FirstName = entity.FirstName;
            }
            return student;
        }


        public static List<Student> Students { get { return _students; } }
    };


}
