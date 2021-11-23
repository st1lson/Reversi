using Reversi.Lib.Enums;
using System.Windows.Controls;

namespace Reversi.GUI.Pages
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private readonly Difficulty _difficulty;

        public GamePage(Difficulty difficulty)
        {
            InitializeComponent();
            _difficulty = difficulty;
        }
    }
}
