using System;
using System.Threading.Tasks;
using System.Timers;

namespace Moodle
{
    class Program
    {

        static GameCharacter hero = new GameCharacter("Arthas", 100, "20", 40);
        static GameCharacter boss = new GameCharacter("Urug", 400, "0-30", 10);

        static async Task Main(string[] args)
        {
            while (hero.Health > 0 && boss.Health > 0)
            {
                await hero.Fight(boss);
                await boss.Fight(hero);
            }

            if (hero.Health == 0)
            {
                Console.WriteLine($"{boss.Name} vant.");
            }
            
            if (boss.Health == 0)
            {
                Console.WriteLine($"{hero.Name} vant.");
            }
        }

    }
}