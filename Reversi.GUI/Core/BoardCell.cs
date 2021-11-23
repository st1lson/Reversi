using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Reversi.GUI.Core
{
    public class BoardCell : INotifyPropertyChanged
    {
        public string? Sign { get; set; }

        public bool CanSelect { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
