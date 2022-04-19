using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public class Player
    {
        private static int _id = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Card> Cards { get; set; }

        public Player(string name)
        {
            Cards = new List<Card>();
            Id = _id;
            Name = name;
            _id++;
        }
    }
}
