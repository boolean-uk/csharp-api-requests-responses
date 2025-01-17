using exercise.wwwapi.DTO;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class StudentCollection
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King", Id = 1 },
            new Student() { FirstName="Dave", LastName="Ames", Id = 2 }
        };

        public static Student Add(Student student)
        {            
            student.Id = _students.Max(x => x.Id) + 1;
            _students.Add(student);

            return student;
        }

        public static List<Student> getAll()
        {
            return _students.ToList();
        }

        public static Student GetById(int id)
        {
            return _students.Where(x => x.Id == id).FirstOrDefault();
        }

        public static bool Remove(int id)
        {
           return _students.Remove(GetById(id));
        }

        public static void Update(Student entity)
        {
            _students.Where(x => x.Id == entity.Id).FirstOrDefault().FirstName = entity.FirstName;
            _students.Where(x => x.Id == entity.Id).FirstOrDefault().LastName = entity.LastName;
        }
    };


}
