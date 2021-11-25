using Reversi.Lib.Enums;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Reversi.GUI.Core
{
    public class BoardCell : INotifyPropertyChanged
    {
        private bool _canSelect = true;
        private Chip _chip = Chip.Empty;

        public bool CanSelect
        {
            get => _canSelect;
            private set
            {
                _canSelect = value;
                OnPropertyChanged();
            }
        }

        public Chip Chip
        {
            get => _chip;
            internal set
            {
                if (CanSelect && value != Chip.Empty)
                {
                    CanSelect = false;
                }

                _chip = value;
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
