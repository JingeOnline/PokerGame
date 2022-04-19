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
                IEnumerable<string> playerNameList = round.Players.Select(x => x.Id + ": " + x.Name);
                string names = string.Join("\n", playerNameList);
                Console.WriteLine("\nPlayers:\n" + names);
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
                //下面两条语句比较高级，不需要理解，作用就是把玩家手中所有牌的Display属性，组合成一个字符串。
                IEnumerable<string> cardsDisplay = player.Cards.Select(x => x.Display);
                string cardsDisplayText = string.Join(",", cardsDisplay);
                Console.WriteLine(cardsDisplayText);
                Console.WriteLine();
            }
        }

    }
}
