using Reversi.GUI.Pages;
using System.Windows;

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
