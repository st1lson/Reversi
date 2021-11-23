using System.Collections.ObjectModel;

namespace Reversi.GUI.Core
{
    public class Board
    {
        public int Rows { get; internal set; }
        public int Columns { get; internal set; }
        public ObservableCollection<BoardCell> Cells { get; }

        public Board()
        {
            Cells = new();
        }
    }
}
