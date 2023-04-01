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
using Pexeso.ViewModels;

namespace Pexeso.Views
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private readonly bool _areTwoPlayes;
        public GameWindow(int rowAmount=6, int columnAmount=6, bool areTwoPlayes = false)
        {
            InitializeComponent();

            _areTwoPlayes = areTwoPlayes;
            Grid board = GameWindowDrawer.DrawBoard(rowAmount, columnAmount);

            GameBoardGrid.Children.Add(board);
        }   
    }
}
