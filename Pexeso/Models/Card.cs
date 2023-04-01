using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Pexeso.Models
{
    public class Card
    {
        public SolidColorBrush Color;
        public Card(SolidColorBrush color)
        {
            this.Color = color;
        }
    }
}
