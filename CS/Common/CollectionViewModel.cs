using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Native;
using System.Collections.ObjectModel;

namespace Common {
    [POCOViewModel]
    public class CollectionViewModel<T> where T : class {
        readonly IDataStorage<T> storage;
        readonly IDetailViewModel detail;

        public virtual ObservableCollection<T> Items { get; protected set; }
        public virtual T SelectedItem { get; set; }

        public CollectionViewModel(IDataStorage<T> storage, IDetailViewModel detail) {
            this.storage = storage;
            this.detail = detail;
            Items = storage.Read().ToObservableCollection();
        }

        protected void OnSelectedItemChanged() {
            if(SelectedItem == null)
                return;
            detail.SetCurrentItem(
                storage.GetId(SelectedItem),
                id => {
                    var item = storage.Find(id);
                    var index = Items.IndexOf(x => storage.GetId(x) == id);
                    Items[index] = item;
                    SelectedItem = item;
                }
            );
        }
    }
}
