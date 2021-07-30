using DevExpress.Mvvm.DataAnnotations;

namespace AutofacDI {
    public interface IDetailViewModel<T> {
        T Item { get; set; }
    }

    [POCOViewModel]
    public class DetailViewModel : IDetailViewModel<Person> {
        readonly ICollectionViewModel<Person> collectionViewModel;

        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual Person Item { get; set; }
        protected void OnItemChanged() => (FirstName, LastName) = (Item?.FirstName, Item?.LastName);

        public DetailViewModel(ICollectionViewModel<Person> collectionViewModel) => this.collectionViewModel = collectionViewModel;

        public void CreateItem() => collectionViewModel.CreateItem(new Person() { FirstName = FirstName, LastName = LastName });
        public bool CanCreateItem() => Item == null;
        public void RefreshItems() => collectionViewModel.RefreshItems();
        public void UpdateItem() => collectionViewModel.UpdateItem(new Person() { FirstName = FirstName, LastName = LastName });
        public bool CanUpdateItem() => Item != null;
        public void DeleteItem() => collectionViewModel.DeleteItem();
        public bool CanDeleteItem() => Item != null;
    }
}
