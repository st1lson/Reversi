using Reversi.Lib.Enums;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Reversi.GUI.Pages
{
    public partial class StartPage : Page
    {
        private Difficulty _difficulty;

        public StartPage()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            int index = Difficulties.SelectedIndex;
            _difficulty = SelectDifficulty(index);
            _ = NavigationService.Navigate(new GamePage(_difficulty));
        }

        private static Difficulty SelectDifficulty(int index) => index switch
        {
            0 => Difficulty.Easy,
            1 => Difficulty.Medium,
            2 => Difficulty.Hard,
            _ => Difficulty.Medium,
        };
    }
}
