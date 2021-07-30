using System.Collections.Generic;

namespace AutofacDI {
    public interface IDataStorage<T> {
        IList<T> Read();
        void Update(T item, int index);
    }
    public class PersonStorage : IDataStorage<Person> {
        IList<Person> items;

        IList<Person> IDataStorage<Person>.Read() => items = new List<Person> {
                new Person() { FirstName = "James", LastName = "Sullivan" },
                new Person() { FirstName = "Mike", LastName = "Wazowski" },
                new Person() { FirstName = "Randall", LastName = "Boggs" }
            };
        void IDataStorage<Person>.Update(Person item, int index) {
            var innerItem = items[index];
            innerItem.FirstName = item.FirstName;
            innerItem.LastName = item.LastName;
        }
    }
}
