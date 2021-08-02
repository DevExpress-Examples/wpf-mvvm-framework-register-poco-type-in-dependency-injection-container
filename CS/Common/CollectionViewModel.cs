using System.Collections.ObjectModel;
using System.Linq;

namespace Common {
    public class CollectionViewModel<T> where T : class {
        readonly IDataStorage<T> storage;
        readonly IDetailViewModel detail;

        public virtual ObservableCollection<T> Items { get; protected set; }
        public virtual T SelectedItem { get; set; }

        public CollectionViewModel(IDataStorage<T> storage, IDetailViewModel detail) {
            this.storage = storage;
            this.detail = detail;
            Items = new ObservableCollection<T>(storage.Read());
        }

        protected void OnSelectedItemChanged() {
            if(SelectedItem == null)
                return;
            detail.SetCurrentItem(
                storage.GetId(SelectedItem),
                id => {
                    var item = storage.Find(id);
                    var localItem = Items.First(x => storage.GetId(x) == id);
                    var index = Items.IndexOf(localItem);
                    Items[index] = item;
                    SelectedItem = item;
                }
            );
        }
    }
}
