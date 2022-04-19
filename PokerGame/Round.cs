using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public class Round
    {
        public List<Card> CardSet { get; set; }
        public List<Player> Players { get; set; }

        public Round()
        {
            
        }

        private void initialCardSet()
        {
            for (int i = 1; i <= 13; i++)
            {
                for(int j=1; j<=4;j++)
                {
                    CardSet.Add(new Card(i, j));
                }
            }
            CardSet.Add(new Card(0, 0));
            CardSet.Add(new Card(1, 0));
        }

        private void shuffleCardSet()
        {
            List<Card> shuffledCards = new List<Card>();

        }
    }
}
