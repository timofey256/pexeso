using Pexeso.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pexeso
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void onStartNewGame(object sender, RoutedEventArgs e)
        {
            int columns, rows;
            bool areTwoPlayers = areTwoPlayersCheckBox.IsChecked ?? false;

            if (int.TryParse(columnsNumber.Text, out columns) &&
                int.TryParse(rowsNumber.Text, out rows))
            {
                if ((columns * rows) % 2 != 0)
                {
                    ShowErrorMessage("Odd amount of cells.");
                }
                else
                {
                    GameWindow gameWindow = new GameWindow(columns, rows, areTwoPlayers);
                    gameWindow.Show();
                }
            }
            else
            {
                ShowErrorMessage("Invalid data. Non-integer columns and/or rows number.");
            }

        }

        private void ShowErrorMessage(string errorMessage)
        {
            ErrorMessageLabel.Content = $"Error: {errorMessage}";
        }
    }
}
