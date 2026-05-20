using System.Collections.ObjectModel;
using System.Linq;

namespace Common {
    public class CollectionViewModel {
        readonly IDataStorage<Person> storage;
        readonly IDetailViewModel detail;

        public virtual ObservableCollection<Person> Items { get; protected set; }
        public virtual Person SelectedItem { get; set; }

        public CollectionViewModel(IDataStorage<Person> storage, IDetailViewModel detail) {
            this.storage = storage;
            this.detail = detail;
            Items = new ObservableCollection<Person>(storage.Read());
        }

        protected void OnSelectedItemChanged() {
            if(SelectedItem == null)
                return;
            detail.SetCurrentItem(
                SelectedItem.Id,
                id => {
                    Person item = storage.Find(id);
                    Person localItem = Items.First(x => x.Id == id);
                    int index = Items.IndexOf(localItem);
                    Items[index] = item;
                    SelectedItem = item;
                }
            );
        }
    }
}
