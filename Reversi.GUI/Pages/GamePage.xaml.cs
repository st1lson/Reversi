using Reversi.GUI.Core;
using Reversi.Lib.Algorithm;
using Reversi.Lib.Enums;
using System.Windows;
using System.Windows.Controls;

namespace Reversi.GUI.Pages
{
    public partial class GamePage : Page
    {
        private readonly Difficulty _difficulty;
        private AlphaBetaPruning _alphaBetaPruning;
        private readonly Board _board;

        public GamePage(Difficulty difficulty)
        {
            InitializeComponent();
            _difficulty = difficulty;
            _board = new();
            _alphaBetaPruning = new(_difficulty);
            Board.ItemsSource = _board.Cells;
            MakeTurn();
        }

        private void CellClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            BoardCell currentCell = (BoardCell)button.DataContext;
            _board.AddCell(_board.Cells.IndexOf(currentCell), Chip.White);
            MakeTurn();
        }

        private void MakeTurn()
        {
            int bestState = _alphaBetaPruning.Find(_board.Chips);
            if (bestState == -1)
            {
                return;
            }
            _board.AddCell(bestState, Chip.Black);
        }
    }
}
