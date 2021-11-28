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
            internal set
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
            _chips = new Chip[64];

            InitializeBoard();
        }

        public void AddCell(int id, Chip chip)
        {
            Cells[id].Chip = Chips[id] = chip;
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < Chips.Length; i++)
            {
                Cells.Add(new BoardCell());
            }

            Cells[27].Chip = Chips[27] = Chip.Black;
            Cells[28].Chip = Chips[28] = Chip.White;
            Cells[35].Chip = Chips[35] = Chip.White;
            Cells[36].Chip = Chips[36] = Chip.Black;
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
