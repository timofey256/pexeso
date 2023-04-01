using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Pexeso.Models
{
    public static class CardsManager
    {
        /// <summary>
        /// Generates deck for a game. Cards are returned in arbitrary order.
        /// </summary>
        /// <param name="cardsAmount"></param>
        /// <returns></returns>
        
        private static Random r = new Random();

        public static List<Card> GenerateDeck(int cardsAmount)
        {
            List<Card> cards = new List<Card>();

            int pairs = cardsAmount / 2;
            for (int i = 0; i < pairs; i++)
            {
                SolidColorBrush brush = GetColor();

                cards.Add(new Card(brush));
                cards.Add(new Card(brush));
            }

            if (cardsAmount / 2 != 0)
                cards.Add(new Card(GetColor()));

            ShuffleCards(cards);
            return cards;
        }

        /// <summary>
        /// Shuffles cards in deck using Fisher-Yates algorithm.
        /// </summary>
        /// <param name="cards"></param>
        private static void ShuffleCards(List<Card> cards)
        {
            int n = cards.Count;

            while (n > 1)
            {
                n--;
                int k = r.Next(n + 1);
                Card temp = cards[k];
                cards[k] = cards[n];
                cards[n] = temp;
            }
            
        }

        private static SolidColorBrush GetColor()
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
                      (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
            return brush;
        }
    }
}
