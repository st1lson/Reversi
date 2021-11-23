using System.Windows;
using Reversi.GUI.Pages;

namespace Reversi.GUI.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new StartPage();
        }
    }
}
