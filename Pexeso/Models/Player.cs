using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pexeso.Models
{
    public class Player
    {
        public string Name { get; set; }

        public int Score { get; private set; } = 0; 
        public Player(string name)
        { 
            Name = name;    
        }

        public void IncreaseScore() => Score += 1;
    }
}
