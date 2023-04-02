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
using System.Windows.Shapes;

namespace Pexeso.Views
{
    /// <summary>
    /// Interaction logic for EndGameWindow.xaml
    /// </summary>
    public partial class EndGameWindow : Window
    {
        public EndGameWindow()
        {
            InitializeComponent();
        }

        private void onReturnToStartMenu(object sender, RoutedEventArgs e)
        {
            var windows = Application.Current.Windows;
            foreach (Window win in windows)
            {
                if (!ReferenceEquals(this, win))
                    win.Close();
            }
            MainWindow newMainWindow = new MainWindow();
            newMainWindow.Show();
            this.Close();
        }
    }
}
