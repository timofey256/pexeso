﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Accessibility;
using Pexeso.Models;
using Pexeso.Views;

namespace Pexeso.ViewModels
{
    public static class GameWindowDrawer
    {
        private static readonly SolidColorBrush _cardBackground = Brushes.Black;
        private static List<Card> cards = new List<Card>();
        private static List<Player> players;
        private static List<int> scores;
        
        public static Grid DrawBoard(int rows, int columns)
        {
            cards = CardsManager.GenerateDeck(rows * columns);

            Grid board = getBoardStructure(rows, columns);
            Grid.SetColumn(board, 1);
            Grid.SetRow(board, 1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Grid wrapper = new Grid();
                    int index = columns * i + j;
                    Button newCardPanel = DrawCard(index);
                    wrapper.Children.Add(newCardPanel);
                    Grid.SetRow(wrapper, i);
                    Grid.SetColumn(wrapper, j);
                    board.Children.Add(wrapper);
                }
            }

            return board;
        }

        public static void InitializePlayers(string name1, string name2) =>
            players = new List<Player> { new Player(name1), new Player(name2) };

        public static void IncreaseScore(int playerIndex) 
        {
            players[playerIndex].IncreaseScore();
        
        }

        public static Grid DrawScorePanel(int playerIndex, int columnIndex, int rowIndex)
        {
            Grid playerPanel = PlayerPanel.GeneratePlayerPanel(players[playerIndex]);
            
            Grid.SetColumn(playerPanel, columnIndex);
            Grid.SetRow(playerPanel, rowIndex);

            return playerPanel;
        }

        private static Grid getBoardStructure(int rows, int columns)
        { 
            Grid board = new Grid();

            for (int i = 0; i < rows; i++)
            {
                board.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < columns; i++)
            {
                board.ColumnDefinitions.Add(new ColumnDefinition());
            }

            return board;
        }

        private static Button DrawCard(int index)
        {
            Button cardRotatingButton = new Button();
            cardRotatingButton.Width = 40;
            cardRotatingButton.Height = 70;
            cardRotatingButton.Margin = new System.Windows.Thickness(10, 10, 10, 10);
            cardRotatingButton.Tag = index;
            cardRotatingButton.Cursor = Cursors.Hand;
            cardRotatingButton.Background = _cardBackground;

            cardRotatingButton.Click += new RoutedEventHandler(GameWindow.onRotateCard);

            return cardRotatingButton;
        }

        public static void RotateCard(Button cardPanel, int cardIndex)
        {
            if (cardPanel.Background == _cardBackground)
                cardPanel.Background = cards[cardIndex].Color;
            else
                cardPanel.Background = _cardBackground;
        }
    }
}
