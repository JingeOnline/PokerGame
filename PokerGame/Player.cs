using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public class Player
    {
        /// <summary>
        /// 注意看这个变量，使用了static，静态修饰符，该变量会被所有对象共享，且只会初始化一次。
        /// </summary>
        private static int _id = 1;
        /// <summary>
        /// 玩家独一无二的Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 玩家名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 玩家手中的牌
        /// </summary>
        public List<Card> Cards { get; set; }

        public Player(string name)
        {
            Cards = new List<Card>();
            Name = name;
            //每创建一个玩家对象，Id就会自动+1.
            Id = _id;
            _id++;
        }
    }
}
