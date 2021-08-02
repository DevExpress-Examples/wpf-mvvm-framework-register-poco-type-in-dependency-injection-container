using System.Collections.Generic;

namespace Common {
    public interface IDataStorage<T> where T : class {
        int GetId(T item);
        T Find(int id);
        IList<T> Read();
        void Update(T item);
    }
}
