using System.ComponentModel;

namespace AutofacDI {
    public interface IDisplayData {
        string DisplayText { get; }
    }
    public class Person : IDisplayData, INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        public string DisplayText => $"{FirstName} {LastName}";

        string firstName;
        public string FirstName {
            get => firstName;
            set {
                if(firstName == value)
                    return;
                firstName = value;
                RaisePropertyChanged(nameof(DisplayText));
            }
        }
        string lastName;
        public string LastName {
            get => lastName;
            set {
                if(lastName == value)
                    return;
                lastName = value;
                RaisePropertyChanged(nameof(DisplayText));
            }
        }

        void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
