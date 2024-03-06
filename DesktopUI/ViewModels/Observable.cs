using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lokata.DesktopUI.ViewModels
{
    public class Observable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(propertyName);
            OnPropertyChanged(propertyName + "IsChanged");
            OnPropertyChanged("IsChanged");
            OnPropertyChanged("DisplayName");
        }
    }
}
