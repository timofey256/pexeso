using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Accessibility;
using Pexeso.Models;

namespace Pexeso.ViewModels
{
    public static class GameWindowDrawer
    {
        public static Grid DrawBoard(int rows, int columns)
        {
            List<Card> cards = CardsManager.GenerateDeck(rows * columns);

            Grid board = getBoardStructure(rows, columns);
            Grid.SetColumn(board, 1);
            Grid.SetRow(board, 1);

            for (int i = 0; i < rows; i++)
            { 
                for (int j=0; j<columns; j++)
                {
                    Grid newCardPanel = DrawCard(cards[j+i*j]);
                    Grid.SetRow(newCardPanel, i);
                    Grid.SetColumn(newCardPanel, j);
                    board.Children.Add(newCardPanel);
                }
            }

            return board;
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

        private static Grid DrawCard(Card card)
        {
            Grid cardPanel = new Grid();
            cardPanel.Width = 40;
            cardPanel.Height = 70;
            cardPanel.Margin = new System.Windows.Thickness(10, 10, 10, 10);
            cardPanel.Background = card.Color;
            return cardPanel;
        }
    }
}
