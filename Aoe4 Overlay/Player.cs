using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoe4_Overlay
{
    internal class Player
    {
        public string name;
        public double games;
        public double wins;
        public int streak;
        public int rating;
        public double winrate;

        public Player(string name, double games, double wins, int streak, int rating)
        {
            this.name = name;
            this.games = games;
            this.wins = wins;
            this.streak = streak;
            this.rating = rating;
            if (games == 0)
            {
                this.winrate = 0;
            } else
            {
                this.winrate = Math.Round(this.wins / this.games * 100);
            }
            
        }
    }
}
