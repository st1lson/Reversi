using Reversi.GUI.Core;
using Reversi.Lib.Enums;
using System.Windows;
using System.Windows.Controls;

namespace Reversi.GUI.Pages
{
    public partial class GamePage : Page
    {
        private readonly Difficulty _difficulty;
        private Board _board;

        public GamePage(Difficulty difficulty)
        {
            InitializeComponent();
            _difficulty = difficulty;
            _board = new();
            for (int i = 0; i < 64; i++)
            {
                _board.Cells.Add(new BoardCell());
            }

            Board.ItemsSource = _board.Cells;
        }

        private void CellClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            BoardCell currentCell = (BoardCell)button.DataContext;
            if (sender is null || ((Button)sender).DataContext as BoardCell is null)
            {
                return;
            }

            currentCell.CanSelect = false;
        }
    }
}
