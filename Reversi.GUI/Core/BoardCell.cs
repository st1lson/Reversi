using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Reversi.GUI.Core
{
    public class BoardCell : INotifyPropertyChanged
    {
        private bool _canSelect = true;

        public bool CanSelect
        {
            get => _canSelect;
            set
            {
                _canSelect = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged is not null)
            {
                PropertyChanged(
                                this,
                                new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
