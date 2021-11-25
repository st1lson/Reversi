using Reversi.Lib.Enums;
using System.Collections.ObjectModel;

namespace Reversi.GUI.Core
{
    public class Board
    {
        public int Rows { get; internal set; }
        public int Columns { get; internal set; }
        public ObservableCollection<BoardCell> Cells { get; }
        private Chip[] _chips;
        public Chip[] Chips
        {
            get => _chips;
            set
            {
                if (value is null)
                {
                    return;
                }

                _chips = value;
                OnChangeChips();
            }
        }

        public Board()
        {
            Cells = new();
            _chips = InitializeBoard();
        }

        public void AddCell(int id, Chip chip)
        {
            Cells[id].Chip = Chips[id] = chip;
        }

        private static Chip[] InitializeBoard()
        {
            return new Chip[64];
        }

        private void OnChangeChips()
        {
            for (int i = 0; i < _chips.Length; i++)
            {
                if (_chips[i].Equals(Cells[i].Chip))
                {
                    continue;
                }

                Cells[i].Chip = _chips[i];
            }
        }
    }
}
