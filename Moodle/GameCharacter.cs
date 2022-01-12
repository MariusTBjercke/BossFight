using System;
using System.Threading.Tasks;

namespace Moodle
{
    internal class GameCharacter
    {

        public string Name { get; set; }
        public int Health { get; set; }
        public string Strength { get; set; }
        public int Stamina { get; set; }
        public int MaxStamina { get; set; }
        public bool Alive { get; set; }

        public GameCharacter(string name, int health, string strength, int stamina, bool alive = true)
        {
            Name = name;
            Health = health;
            Strength = strength;
            Stamina = stamina;
            MaxStamina = stamina;
            Alive = alive;
        }

        public async Task Fight(GameCharacter player2)
        {
            var random = new Random();

            if (Stamina == 0)
            {
                Recharge();
            }
            else
            {
                int finalStrength;
                Console.ForegroundColor = ConsoleColor.Red;
                if (Strength.Contains('-'))
                {
                    var strengthParts = Strength.Split('-');
                    var min = Convert.ToInt32(strengthParts[0]);
                    var max = Convert.ToInt32(strengthParts[1]) + 1;
                    finalStrength = random.Next(min, max);
                    player2.Health -= finalStrength;
                    Console.WriteLine($"{Name} tok {finalStrength} skade fra {player2.Name}");
                }
                else
                {
                    finalStrength = Convert.ToInt32(Strength);
                    player2.Health -= finalStrength;
                    Console.WriteLine($"{Name} tok {finalStrength} skade fra {player2.Name}");
                }
                Stamina -= 10;
                Console.ForegroundColor = ConsoleColor.White;
                if (player2.Health > 0) Console.WriteLine($"{player2.Name} har {player2.Health} HP igjen.");
                // Added this for later use
                else player2.Alive = false;
            }

            await Task.Delay(800);
        }

        public void Recharge()
        {
            Stamina = MaxStamina;
            Console.WriteLine($"{Name} har ikke nok stamina. Bruker 'Recharge'.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} fikk tilbake {MaxStamina} stamina.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
