using System.Collections.Generic;
using System.Linq;

namespace Common {
    public interface IDataStorage<T> where T : class {
        T Find(int id);
        IList<T> Read();
        void Update(T item);
    }

    public class PersonStorage : IDataStorage<Person> {
        readonly IList<Person> items = new List<Person> {
            new Person() { Id = 0, FirstName = "Bruce", LastName = "Cambell" },
            new Person() { Id = 1, FirstName = "Cindy", LastName = "Haneline" },
            new Person() { Id = 2, FirstName = "Andrea", LastName = "Deville" },
            new Person() { Id = 3, FirstName = "Anita", LastName = "Ryan" },
            new Person() { Id = 4, FirstName = "George", LastName = "Bunkelman" },
            new Person() { Id = 5, FirstName = "Anita", LastName = "Cardle" },
            new Person() { Id = 6, FirstName = "Andrew", LastName = "Carter" },
            new Person() { Id = 7, FirstName = "Almas", LastName = "Basinger" },
            new Person() { Id = 8, FirstName = "Carolyn", LastName = "Baker" },
            new Person() { Id = 9, FirstName = "Anthony", LastName = "Rounds" },
        };

        Person IDataStorage<Person>.Find(int id) => Clone(FindCore(id));
        IList<Person> IDataStorage<Person>.Read() => items.Select(x => Clone(x)).ToList();
        void IDataStorage<Person>.Update(Person item) {
            var storageItem = FindCore(item.Id);
            storageItem.FirstName = item.FirstName;
            storageItem.LastName = item.LastName;
        }

        static Person Clone(Person x) => new Person { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName };
        Person FindCore(int id) => items.First(x => x.Id == id);
    }
}
