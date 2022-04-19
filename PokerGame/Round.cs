using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public class Round
    {
        public List<Card> CardSet = new List<Card>();
        public List<Player> Players = new List<Player>();
        Random random = new Random();

        public Round(string userName)
        {
            initialCardSet();
            createPlayers();
            Players.Add(new Player(userName));
            shuffleCards();
            distributeCards();
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

        private void shuffleCards()
        {
            List<Card> shuffledSet = new List<Card>();
            while (CardSet.Count() != 0)
            {
                Card card = getRandomCard(CardSet);
                CardSet.Remove(card);
                shuffledSet.Add(card);
            }
            CardSet = shuffledSet;
        }

        private Card getRandomCard(List<Card> cards)
        {
            
            int index = random.Next(0, cards.Count());
            return cards[index];
        }

        private void createPlayers()
        {
            Player p1 = new Player("石头");
            Player p2 = new Player("老高");
            Player p3 = new Player("方砖");
            Player p4 = new Player("老雷");
            Player p5 = new Player("袁腾飞");
            Player p6 = new Player("悉尼奶爸");
            Player p7 = new Player("五月散人");
            Player p8 = new Player("狗哥");

            List<Player> players = new List<Player>() { p1,p2,p3,p4,p5,p6,p7,p8 };
            Random rd = new Random();
            int playerCount = 3;
            while (playerCount > 0)
            {
                int index = rd.Next(0, players.Count);
                Players.Add(players[index]);
                players.RemoveAt(index);
                playerCount--;
            }
        }

        private void distributeCards()
        {
            int cardIndex = CardSet.Count-1;
            while (cardIndex>=0)
            {
                int mod = cardIndex % 4;
                Players[mod].Cards.Add(CardSet[cardIndex]);
                cardIndex--;
            }
        }
    }
}
