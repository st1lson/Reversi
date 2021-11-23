using System.Windows;
using Reversi.GUI.Pages;

namespace Reversi.GUI.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new StartPage();
        }
    }
}
