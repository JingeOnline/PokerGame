using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    /// <summary>
    /// 一场游戏
    /// </summary>
    public class Round
    {
        /// <summary>
        /// 本局游戏的纸牌组
        /// </summary>
        public List<Card> CardSet = new List<Card>();
        /// <summary>
        /// 本局游戏的玩家
        /// </summary>
        public List<Player> Players = new List<Player>();
        /// <summary>
        /// 用于创建随机数的一个对象
        /// </summary>
        Random random = new Random();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userName">传入用户设置的玩家名称</param>
        public Round(string userName)
        {
            initialCardSet();
            createAiPlayers();
            Players.Add(new Player(userName));
            shuffleCards();
            distributeCards();
        }

        /// <summary>
        /// 初始化一整副牌
        /// </summary>
        private void initialCardSet()
        {
            for (int i = 1; i <= 13; i++)
            {
                for(int j=1; j<=4;j++)
                {
                    CardSet.Add(new Card(i, j));
                }
            }
            //创建大小王，添加到纸牌组中
            CardSet.Add(new Card(0, 0));
            CardSet.Add(new Card(1, 0));
        }

        /// <summary>
        /// 洗牌，打乱CardSet中Card的顺序
        /// </summary>
        private void shuffleCards()
        {
            List<Card> shuffledSet = new List<Card>();
            //循环抽牌放倒新的卡片组中，直到原始的卡片组一张不剩。
            while (CardSet.Count() != 0)
            {
                Card card = getRandomCard(CardSet);
                CardSet.Remove(card);
                shuffledSet.Add(card);
            }
            CardSet = shuffledSet;
        }

        /// <summary>
        /// 从一组牌中随机抽取一张牌
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private Card getRandomCard(List<Card> cards)
        {
            //不在此处声明Random对象，而在全局声明，是为了减少性能开销，并避免重复使用同一组随机种子来抽取。
            int index = random.Next(0, cards.Count());
            return cards[index];
        }

        /// <summary>
        /// 创建3个AI玩家，这3个玩家是从8个玩家中随机选出的。
        /// </summary>
        private void createAiPlayers()
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
        /// <summary>
        /// 四个玩家轮流抓牌
        /// </summary>
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
