using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public class Card
    {
        public int Id { get; set; }
        public int Num { get; set; }
        public int SuitType { get; set; }
        public string Suit { get; set; }
        public string Display { get; set; }

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

        private int getId(int num, int suitType)
        {
            return num + ((suitType-1)*13);
        }
    }
}
