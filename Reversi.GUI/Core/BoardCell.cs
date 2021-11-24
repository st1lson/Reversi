using Reversi.GUI.Core.Enums;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace Reversi.GUI.Core
{
    public class BoardCell : INotifyPropertyChanged
    {
        private bool _canSelect = true;
        private Chip _chip = Chip.Empty;
        private BitmapImage _image = new();

        public bool CanSelect
        {
            get => _canSelect;
            set
            {
                _canSelect = value;
                OnPropertyChanged();
            }
        }

        public Chip Chip
        {
            get => _chip;
            set
            {
                _chip = value;
                OnPropertyChanged();
            }
        }

        public BitmapImage Image
        {
            get => _image;
            set
            {
                _image = value;
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
