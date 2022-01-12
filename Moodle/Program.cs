using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moodle
{
    class Program
    {
        private static List<GameCharacter> players = new List<GameCharacter>();
        static Random rnd = new Random();

        static async Task Main(string[] args)
        {
            int first = rnd.Next(0, 2);
            int last = first == 0 ? 1 : 0;

            // Players (Two player support only)
            players.Add(new GameCharacter("Arthas", 100, "20", 40));
            players.Add(new GameCharacter("Urug", 400, "0-30", 10));

            while (players[0].Health > 0 && players[1].Health > 0)
            {
                await players[first].Fight(players[last]);
                await players[last].Fight(players[first]);
            }

            CheckForWinner();
        }

        private static void CheckForWinner()
        {
            var alive = players.FindIndex(p => p.Alive);
            var dead = players.FindIndex(p => !p.Alive);
            Console.WriteLine($"{players[dead].Name} døde :(");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{players[alive].Name} vant!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}