﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
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
        private static Button? firstCard = null;
        private static int cardsLeft;
        public GameWindow(int rowAmount=2, int columnAmount=2, bool areTwoPlayes = false)
        {
            InitializeComponent();

            _areTwoPlayes = areTwoPlayes;
            cardsLeft = rowAmount * columnAmount;
            Grid board = GameWindowDrawer.DrawBoard(rowAmount, columnAmount);

            GameBoardGrid.Children.Add(board);
        }

        public static void onRotateCard(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int cardIndex = (int)button.Tag;
            GameWindowDrawer.RotateCard(button, cardIndex);

            if (firstCard is null)
            {
                firstCard = button;
            }
            else if (!ReferenceEquals(firstCard, button) && firstCard.Background == button.Background) 
            {
                button.IsEnabled = false;
                firstCard.IsEnabled = false;
                cardsLeft -= 2;
                ValidateCardsLeft();
            }
            else 
            {
                GameWindowDrawer.RotateCard(button, cardIndex);
                GameWindowDrawer.RotateCard(firstCard, (int)firstCard.Tag);
                firstCard = null;
            }
        }

        private static void ValidateCardsLeft()
        {
            if (cardsLeft == 0)
            {
                EndGameWindow endGameWindow = new EndGameWindow();
                endGameWindow.Show();
            }
        }
    }
}
