using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public GameCharacter(string name, int health, string strength, int stamina)
        {
            Name = name;
            Health = health;
            Strength = strength;
            Stamina = stamina;
            MaxStamina = stamina;
        }

        public async Task Fight(GameCharacter player2)
        {
            var random = new Random();

            if (Stamina == 0)
            {
                Recharge();
                Console.WriteLine(Name + " har ikke nok stamina. Bruker 'recharge'.");
            }
            else
            {
                int newStrength;
                Console.ForegroundColor = ConsoleColor.Red;
                if (Strength.Contains('-'))
                {
                    var strengthParts = Strength.Split('-');
                    var min = Convert.ToInt32(strengthParts[0]);
                    var max = Convert.ToInt32(strengthParts[1]) + 1;
                    newStrength = random.Next(min, max);
                    player2.Health -= newStrength;
                    Console.WriteLine(Name + " tok " + newStrength + " skade fra " + player2.Name + ".");
                }
                else
                {
                    newStrength = Convert.ToInt32(Strength);
                    player2.Health -= newStrength;
                    Console.WriteLine(Name + " tok " + newStrength + " skade fra " + player2.Name + ".");
                }
                Stamina -= 10;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(player2.Name + " har " + player2.Health + "HP igjen.");
            }

            await Task.Delay(1000);
        }

        public void Recharge()
        {
            Stamina = MaxStamina;
            Console.WriteLine(Name + " fikk " + MaxStamina);
        }
    }
}
