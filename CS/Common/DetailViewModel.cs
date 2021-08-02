using DevExpress.Mvvm.DataAnnotations;
using System;

namespace Common {
    public interface IDetailViewModel {
        void SetCurrentItem(int id, Action<int> onItemUpdated);
    }
    [POCOViewModel]
    public class DetailViewModel<T> : IDetailViewModel where T : class {
        readonly IDataStorage<T> storage;
        Action<int> onItemUpdated;

        public virtual T Item { get; set; }
        public DetailViewModel(IDataStorage<T> storage) => this.storage = storage;

        void IDetailViewModel.SetCurrentItem(int id, Action<int> onItemUpdated) {
            Item = storage.Find(id);
            this.onItemUpdated = onItemUpdated;
        }
        public void Update() {
            storage.Update(Item);
            onItemUpdated(storage.GetId(Item));
        }
        public bool CanUpdate() => Item != null;
    }
}
