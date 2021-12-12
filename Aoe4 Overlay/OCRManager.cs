using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronOcr;

namespace Aoe4_Overlay
{
    internal class OCRManager
    {
        IronTesseract IronOcr = new IronTesseract();


        public Player[] GetPlayers()
        {
            Screenshooter screen = new Screenshooter();
            IronOcr.Language = OcrLanguage.EnglishBest;
            string player1Name = new IronTesseract().Read(EnhanceInput(screen.GetPlayer1())).Text;
            string player2Name = new IronTesseract().Read(EnhanceInput(screen.GetPlayer2())).Text;
            string player3Name = new IronTesseract().Read(EnhanceInput(screen.GetPlayer3())).Text;
            string player4Name = new IronTesseract().Read(EnhanceInput(screen.GetPlayer4())).Text;
            Player[] players = new Player[4];
            int mode = 18; //2vs2-18        1vs1-17
            if (is1vs1(player3Name, player4Name))
            {
                mode = 17;
                players[0] = new Player(player1Name, GetGames(player1Name, mode), GetWins(player1Name, mode), GetStreak(player1Name, mode), GetRating(player1Name, mode));
                players[1] = new Player(player2Name, GetGames(player2Name, mode), GetWins(player2Name, mode), GetStreak(player2Name, mode), GetRating(player2Name, mode));
                players[2] = new Player("", 0, 0, 0, 0);
                players[3] = new Player("", 0, 0, 0, 0);

                return players;


            }
            else
            {

                players[0] = new Player(player1Name, GetGames(player1Name, mode), GetWins(player1Name, mode), GetStreak(player1Name, mode), GetRating(player1Name, mode));
                players[1] = new Player(player2Name, GetGames(player2Name, mode), GetWins(player2Name, mode), GetStreak(player2Name, mode), GetRating(player2Name, mode));
                players[2] = new Player(player3Name, GetGames(player3Name, mode), GetWins(player3Name, mode), GetStreak(player3Name, mode), GetRating(player3Name, mode));
                players[3] = new Player(player4Name, GetGames(player4Name, mode), GetWins(player4Name, mode), GetStreak(player4Name, mode), GetRating(player4Name, mode));

                return players;
            }
        }

        private bool is1vs1(string player3, string player4)
        {
            if (player3.Equals("") || player4.Equals(""))
            {
                return true;
            } else
            return false;
        }

        private OcrInput EnhanceInput(Bitmap bitmap)
        {
            var Input = new OcrInput(bitmap);
            Input.EnhanceResolution();
            Input.Contrast();
            Input.Invert();
            return Input;
        }

        private int GetGames(string player , int mode)
        {
            int response;
            try
            {
                response = new LadderResponse().GetPlayerData2vs2(player, mode).leaderboard[0].games;
            } catch
            {
                return 0;
            }
            return response;
        }

        private int GetWins(string player, int mode)
        {
            int response;
            try
            {
                response = new LadderResponse().GetPlayerData2vs2(player, mode).leaderboard[0].wins;
            }
            catch
            {
                return 0;
            }
            return response;
        }

        private int GetStreak(string player, int mode)
        {
            int response;
            try
            {
                response = new LadderResponse().GetPlayerData2vs2(player, mode).leaderboard[0].streak;
            }
            catch
            {
                return 0;
            }
            return response;
        }

        private int GetRating(string player, int mode)
        {
            int response;
            try
            {
                response = new LadderResponse().GetPlayerData2vs2(player, mode).leaderboard[0].rating;
            }
            catch
            {
                return 0;
            }
            return response;
        }
       
    }
}
