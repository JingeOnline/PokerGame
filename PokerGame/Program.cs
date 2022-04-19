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
            Console.OutputEncoding = Encoding.UTF8;

            Play();

            Console.Write("\nPress any key to exit.");
            Console.ReadKey();
        }

        static void Play()
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

        static void countDown()
        {
            Console.WriteLine();
            int seconds = 5;
            while (seconds > 0)
            {
                Console.WriteLine($"Game will start in {seconds} seconds...");
                Thread.Sleep(1000);
                seconds--;
            }
        }

        static void showPlayersCards(List<Player> players)
        {
            Console.WriteLine();
            foreach(Player player in players)
            {
                Console.WriteLine(player.Name + ":");
                IEnumerable<string> cardsDisplay = player.Cards.Select(x => x.Display);
                string cardsDisplayText = string.Join(",", cardsDisplay);
                Console.WriteLine(cardsDisplayText);
                Console.WriteLine();
            }
        }

    }
}
