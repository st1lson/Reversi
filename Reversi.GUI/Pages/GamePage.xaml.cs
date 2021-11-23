using Reversi.GUI.Core;
using Reversi.Lib.Enums;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Reversi.GUI.Pages
{
    public partial class GamePage : Page
    {
        private readonly Difficulty _difficulty;

        public GamePage(Difficulty difficulty)
        {
            InitializeComponent();
            _difficulty = difficulty;
            Board board = new();
            for (int i = 0; i < 64; i++)
            {
                board.Cells.Add(new BoardCell());
            }

            Board.ItemsSource = board.Cells;
        }

        private void CellClick(object sender, RoutedEventArgs e)
        {
            if (sender is null)
            {
                return;
            }

            _ = ((Button)sender).DataContext as BoardCell;
            System.Console.WriteLine(":(");
        }
    }
}
