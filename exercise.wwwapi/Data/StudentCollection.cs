using System;
using System.Collections.Generic;
using System.Linq;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    // Ensure StudentCollection implements IColl<Student>
    public class StudentCollection : IColl<Student>
    {
        private List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan", LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        // Implement Add to satisfy IColl<Student>
        public Student Add(Student entity)
        {
            _students.Add(entity);
            return entity;
        }

        // Implement GetAll to satisfy IColl<Student>
        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        // Implement GetById to satisfy IColl<Student>, assuming Id is a unique identifier
        public Student GetById(object id)
        {
            return _students.FirstOrDefault(s => s.FirstName.Equals(id));
        }

        // Implement Remove to satisfy IColl<Student>, using Id for simplicity
        public Student Remove(object id)
        {
            var student = GetById(id);
            if (student != null)
            {
                _students.Remove(student);
            }
            return student;
        }

        // Implement Update to satisfy IColl<Student>
        public Student Update(Student entity)
        {
            var student = GetById(entity.FirstName);
            if (student != null)
            {
                // Assuming you update all relevant fields
                student.FirstName = entity.FirstName;
                student.LastName = entity.LastName;
                // Add other fields to update as necessary
            }
            return student;
        }

        // Implement Update with id and entity for IColl<Student>
        public Student Update(object id, Student entity)
        {
            var student = GetById(id);
            if (student != null)
            {
                // Update logic here, similar to the Update method above
                student.FirstName = entity.FirstName;
                student.LastName = entity.LastName;
                // Add other fields to update as necessary
            }
            return student;
        }
    }
}
