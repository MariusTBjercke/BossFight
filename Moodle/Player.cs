using System;

namespace Moodle
{
    internal class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public readonly Random _random;

        public Player(string name, int score, Random random)
        {
            Name = name;
            Score = score;
            _random = random;
        }

        public void Play(Player player2)
        {
            var winner = _random.Next(2) == 0 ? this : player2;
            var loser = winner == this ? player2 : this;
            winner.Score += 1;
            loser.Score -= 1;
        }

        public void ShowNameAndPoints()
        {
            Console.WriteLine(Name.PadRight(12) + Score.ToString().PadLeft(3));
        }

    }
}
