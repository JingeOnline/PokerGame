using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //设置打印所使用的字符集，默认的字符集打印不出Emoji。
            Console.OutputEncoding = Encoding.UTF8;

            PlayARound();

            Console.Write("\nPress any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// 开始一轮游戏
        /// </summary>
        static void PlayARound()
        {
            if (isUserPlay())
            {
                Console.WriteLine("\nPlease input your player name:");
                string username = Console.ReadLine();
                Round round = new Round(username);
                IEnumerable<string> playerNameList = round.Players.Select(x => x.Id + "-" + x.Name);
                string names = string.Join("\n\t", playerNameList);
                Console.WriteLine("\nPlayers:\n\t" + names);
                countDown();
                showPlayersCards(round.Players);
            }
        }
        /// <summary>
        /// 玩家是否选中开始游戏
        /// </summary>
        /// <returns></returns>
        static bool isUserPlay()
        {
            Console.WriteLine("Would you like play a poker game? Y/N");
            string isPlay = Console.ReadLine();
            if (isPlay == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 模拟倒计时
        /// </summary>
        static void countDown()
        {
            Console.WriteLine();
            int seconds = 5;
            while (seconds > 0)
            {
                Console.WriteLine($"Game will start in {seconds} seconds...");
                //当前线程暂停1秒
                Thread.Sleep(1000);
                seconds--;
            }
        }
        /// <summary>
        /// 列出当前玩家手中所有的牌
        /// </summary>
        /// <param name="players">传入一个Player类型的List</param>
        static void showPlayersCards(List<Player> players)
        {
            Console.WriteLine();
            foreach(Player player in players)
            {
                Console.WriteLine(player.Name + ":");
                
                showCardsDisplayAndIdInColumn(player.Cards);
                Console.WriteLine();
            }
        }
        /// <summary>
        /// 把一组牌打印到控制台上，显示格式尽量好看一点
        /// </summary>
        /// <param name="cards"></param>
        static void showCardsDisplayAndIdInColumn(IEnumerable<Card> cards)
        {
            //先从小到大排序
            cards=cards.OrderBy(x => x.Num);
            IEnumerable<string> cardsDisplay = cards.Select(x => x.Display);
            List<string> formatedDisplays = new List<string>();

            foreach (string s in cardsDisplay)
            {
                int widthGap = getTextWidthGap(s);
                if (widthGap == 0)
                {
                    formatedDisplays.Add(string.Format("{0,-5}", s));
                }
                else if (widthGap == 1)
                {
                    formatedDisplays.Add(string.Format("{0,-4}", s));
                }
                else if (widthGap == 2)
                {
                    formatedDisplays.Add(string.Format("{0,-3}", s));
                }
            }
            //下面两条语句比较高级，不需要理解，作用就是把玩家手中所有牌的Display属性，组合成一个字符串。
            string cardsDisplayText = string.Join("|", formatedDisplays);
            IEnumerable<string> cardsId = cards.Select(x => x.Id.ToString());
            //格式化字符串宽度和对齐方式
            cardsId = cardsId.Select(x => string.Format("{0,-5}", x));
            string cardsIdText = string.Join("|", cardsId);

            Console.WriteLine(cardsDisplayText);
            Console.WriteLine(cardsIdText);
        }

        /// <summary>
        /// 由于中文字符，西文字符，Emoji字符的宽度不一样，为了对齐文字，需要检测文字中有几个非英文的字符。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static int getTextWidthGap(string text)
        {
            int width = 0;
            foreach(char c in text)
            {
                if (c > 127)
                {
                    width++;
                }
            }
            return width; 
        }

    }
}
