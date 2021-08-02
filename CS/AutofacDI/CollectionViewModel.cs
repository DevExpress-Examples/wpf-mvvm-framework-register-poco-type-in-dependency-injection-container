using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Native;
using System.Collections.ObjectModel;

namespace AutofacDI {
    [POCOViewModel]
    public class CollectionViewModel {
        readonly IDataStorage<Person> storage;
        readonly IDetailViewModel detail;

        public virtual ObservableCollection<Person> Items { get; protected set; }
        public virtual Person SelectedItem { get; set; }

        public CollectionViewModel(IDataStorage<Person> storage, IDetailViewModel detail) {
            this.storage = storage;
            this.detail = detail;
            Items = storage.Read().ToObservableCollection();
        }

        protected void OnSelectedItemChanged() {
            if(SelectedItem == null)
                return;
            detail.SetCurrentItem(
                SelectedItem.Id,
                id => {
                    var item = storage.Find(id);
                    var index = Items.IndexOf(x => x.Id == id);
                    Items[index] = item;
                }
            );
        }
    }
}
