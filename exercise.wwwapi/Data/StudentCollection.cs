using exercise.wwwapi.Models;
using System.Reflection.Metadata.Ecma335;

namespace exercise.wwwapi.Data
{
    public static class StudentCollection
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public static Student Add(Student entity)
        {
            var entityExists = _students.FirstOrDefault(x => $"{x.FirstName}+{x.LastName}".Equals($"{entity.FirstName}+{entity.LastName}"));
            if (entityExists is not null)
            {
                return null;
            }
            _students.Add(entity);
            return entity;
        }

        public static List<Student> GetAll()
        {
            return _students.ToList();
        }

        public static Student Get(string firstName)
        {
            return _students.FirstOrDefault(x => x.FirstName == firstName);
        }

        public static Student Update(string firstName, Student entity)
        {
            var index = _students.FindIndex(x => x.FirstName == firstName);
            if (index == -1)
            {
                return null;
            }

            _students[index] = entity;
            return entity;
        }

        public static Student Delete(string firstName)
        {
            var foundEntity = _students.FirstOrDefault(x => x.FirstName == firstName);
            if (foundEntity is null)
            {
                return null;
            }

            _students.Remove(foundEntity);
            return foundEntity;
        }
    };
}
