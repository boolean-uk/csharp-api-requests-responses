using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Globalization;

namespace exercise.wwwapi.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly List<T> _items;
        public GenericRepository()
        {
            if (typeof(T) == typeof(Student))
            {
                _items = InMemoryDataCollection.Students.Cast<T>().ToList();
            }
            else if (typeof(T) == typeof(Book))
            {
                _items = InMemoryDataCollection.Books.Cast<T>().ToList();
            }
            else if (typeof(T) == typeof(Language))
            {
                _items = InMemoryDataCollection.Languages.Cast<T>().ToList();
            }
            else
            {
                _items = new List<T>();
            }
        }
    
            public T createElement(T entity)
        {
            var stringProperty = typeof(T).GetProperties()
                .FirstOrDefault(prop => prop.PropertyType == typeof(string));

            if (stringProperty == null)
            {
                throw new InvalidOperationException($"No string property found on type {typeof(T).Name}");
            }

            var propertyValue = (string)stringProperty.GetValue(entity);
            var existing = _items.FirstOrDefault(item => (string)stringProperty.GetValue(item) == propertyValue);

            if (existing != null)
            {
                throw new InvalidOperationException($"Entity with the same {stringProperty.Name} already exists.");
            }

            _items.Add(entity);
            return entity;
        }

        public T deleteElement(string name)
        {
           var element = getElementByName(name);
            
            if (element != null)
            {
                _items.Remove(element);
            }
            return element;
        }

        public IEnumerable<T> getAll()
        {
            return _items;
        }

        public T getElementByName(string name)
        {
            var type = typeof(T).GetProperties().FirstOrDefault(prop => prop.PropertyType == typeof(string));

            if (name == null)
            {
                throw new InvalidOperationException($"No string property found on type {typeof(T).Name}");


            }
            return _items.FirstOrDefault(item => (string)type.GetValue(item) == name);
        }



        public T updateElement(T element)
        {
            var stringProperty = typeof(T).GetProperties()
                .FirstOrDefault(prop => prop.PropertyType == typeof(string));

            if (stringProperty == null)
            {
                throw new InvalidOperationException($"No string property found on type {typeof(T).Name}");
            }

            var propertyValue = (string)stringProperty.GetValue(element);
            var existing = _items.FirstOrDefault(item => (string)stringProperty.GetValue(item) == propertyValue);

            if (existing == null)
            {
                throw new InvalidOperationException("Entity not found.");
            }

            var index = _items.IndexOf(existing);
            _items[index] = element;
            return element;
        }
    }
}


