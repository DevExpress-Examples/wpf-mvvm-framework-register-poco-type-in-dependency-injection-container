using DevExpress.Mvvm.DataAnnotations;
using System;

namespace AutofacDI {
    public interface IDetailViewModel {
        void SetCurrentItem(int id, Action<int> onItemUpdated);
    }
    [POCOViewModel]
    public class DetailViewModel : IDetailViewModel {
        readonly IDataStorage<Person> storage;
        Action<int> onItemUpdated;

        public virtual Person Item { get; set; }
        public DetailViewModel(IDataStorage<Person> storage) => this.storage = storage;

        void IDetailViewModel.SetCurrentItem(int id, Action<int> onItemUpdated) {
            Item = storage.Find(id);
            this.onItemUpdated = Item != null ? onItemUpdated : null;
        }
        public void Update() {
            storage.Update(Item);
            onItemUpdated(Item.Id);
        }
        public bool CanUpdate() => Item != null;
    }
}
