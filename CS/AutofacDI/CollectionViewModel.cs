using Autofac;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Native;
using System.Collections.ObjectModel;

namespace AutofacDI {
    public interface ICollectionViewModel<T> {
        void CreateItem(T item);
        void RefreshItems();
        void UpdateItem(T item);
        void DeleteItem();
    }

    [POCOViewModel]
    public class CollectionViewModel : ICollectionViewModel<Person> {
        readonly IDataStorage<Person> storage;

        public virtual IDetailViewModel<Person> Detail { get; protected set; }
        public virtual ObservableCollection<Person> Items { get; protected set; }
        public virtual Person SelectedItem { get; set; }
        protected void OnSelectedItemChanged() => Detail.Item = SelectedItem;

        public CollectionViewModel(ServiceLocator locator) {
            Detail = locator.container.Resolve<IDetailViewModel<Person>>(new NamedParameter("collectionViewModel", this));
            storage = locator.container.Resolve<IDataStorage<Person>>();
            Items = storage.Read().ToObservableCollection();
        }

        void ICollectionViewModel<Person>.CreateItem(Person item) => Items.Add(item);
        void ICollectionViewModel<Person>.RefreshItems() => Items = storage.Read().ToObservableCollection();
        void ICollectionViewModel<Person>.UpdateItem(Person item) {
            SelectedItem.FirstName = item.FirstName;
            SelectedItem.LastName = item.LastName;
            SelectedItem = null;
        }
        void ICollectionViewModel<Person>.DeleteItem() => Items.Remove(SelectedItem);
    }
}
