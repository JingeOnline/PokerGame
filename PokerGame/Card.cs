using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public class Card
    {
        /// <summary>
        /// 每张牌独一无二的序号1-54
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 每张牌上面的数字
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 花色类型序号
        /// </summary>
        public int SuitType { get; set; }
        /// <summary>
        /// 花色类型符号Emoji
        /// </summary>
        public string Suit { get; set; }
        /// <summary>
        /// 用于显示给玩家的完整的纸牌内容
        /// </summary>
        public string Display { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="num">0-13，共14种数值类型</param>
        /// <param name="suitType">0-4，共5种花色类型</param>
        public Card(int num, int suitType)
        {
            //如果不是大小王
            if (suitType>0)
            {
                Num = num;
                Suit = getSuitByType(suitType);
                Id = getId(num, suitType);

                switch (num)
                {
                    case 1:
                        Display = Suit + "A";
                        break;
                    case 11:
                        Display = Suit + "J";
                        break;
                    case 12:
                        Display = Suit + "Q";
                        break;
                    case 13:
                        Display = Suit + "K";
                        break;
                    default:
                        Display = Suit + num;
                        break;
                }
            }
            //大王和小王
            else
            {
                if (num == 0)
                {
                    Id = 53;
                    Num = 0;
                    SuitType = 0;
                    Suit = "Joker";
                    Display = "小王";
                }
                else
                {
                    Id = 54;
                    Num = 1;
                    SuitType = 0;
                    Suit = "Joker";
                    Display = "大王";
                }
            }
            
        }

        //根据花色的类型的数字，设置花色
        private string getSuitByType(int suitType)
        {
            switch (suitType)
            {
                case 1:
                    return "♦";
                case 2:
                    return "♣";
                case 3:
                    return "♥";
                case 4:
                    return "♠";
                default:
                    return null;
            }
        }

        //根据花色和数值来为每一张牌设置一个独立的Id
        private int getId(int num, int suitType)
        {
            return num + ((suitType-1)*13);
        }
    }
}
