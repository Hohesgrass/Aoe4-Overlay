using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoe4_Overlay
{
    internal class PlayerCreator
    {
 
        private Rectangle[] playerPositions = {new Rectangle(134, 220, 150, 50), new Rectangle(134, 280, 150, 50), new Rectangle(134, 340, 150, 50), new Rectangle(134, 400, 150, 50) };
        private readonly AoeClient aoeClient;
        
        public PlayerCreator()
        {
            aoeClient = new AoeClient();
        }

        public async Task<Player[]> GetPlayersAsync()
        {
            string[] playernames = MakeNameArray();
            Player[] players = await CreatePlayersAsync(playernames);
            return players;
        }


        private async Task<Player[]> CreatePlayersAsync(string[] playernames)
        {
            Player[] players = new Player[playernames.Length];
            int mode = 18;
            if (!(Is1vs1(playernames[2], playernames[3])))
            {
                for (int i = 0; i < playernames.Length; i++)
                {
                    var ladder = await aoeClient.GetPlayerDataAsync(playernames[i], mode);
                    players[i] = new Player(playernames[i], GetGames(ladder), GetWins(ladder), GetStreak(ladder), GetRating(ladder));
                }
            } else {
                mode = 17;
                for (int i = 0; i < 2; i++)
                {
                    var ladder = await aoeClient.GetPlayerDataAsync(playernames[i], mode);
                    players[i] = new Player(playernames[i], GetGames(ladder), GetWins(ladder), GetStreak(ladder), GetRating(ladder));
                    players[2] = new Player("", 0, 0, 0, 0);
                    players[3] = new Player("", 0, 0, 0, 0);
                }
            }
            return players;
        }
        
        private string[] MakeNameArray()
        {
            string[] players = new string[4];
            OCRManager ocr = new OCRManager();
            for (int i = 0; i < players.Length; i++)
            {
                players[i] = ocr.DoOCR(playerPositions[i]);
            }
            return players;
        }

        private bool Is1vs1(string player3, string player4)
        {
            if (player3.Equals("") || player4.Equals(""))
            {
                return true;
            }
            else
                return false;
        }

        private int GetGames(LadderResponse lr)
        {
            return lr.Leaderboard[0].games;
        }

        private int GetWins(LadderResponse lr)
        {
            return lr.Leaderboard[0].wins;
        }

        private int GetStreak(LadderResponse lr)
        {
           
            return lr.Leaderboard[0].streak;
        }

        private int GetRating(LadderResponse lr)
        {
            return lr.Leaderboard[0].rating;
        }
    }
}
