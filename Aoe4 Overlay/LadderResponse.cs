using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Aoe4_Overlay
{
    internal class LadderResponse
    {
        private string REQUESTURL = "https://aoeiv.net/api/leaderboard?game=aoe4";
        public List<Leaderboard> leaderboard;

        public LadderResponse GetPlayerData2vs2(string player, int mode)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponse = httpClient.GetAsync(REQUESTURL + "&leaderboard_id=" + mode + "&search=" + player + "&count=1").Result;
            string response = httpResponse.Content.ReadAsStringAsync().Result;
#pragma warning disable CS8600 // Das NULL-Literal oder ein möglicher NULL-Wert wird in einen Non-Nullable-Typ konvertiert.
            LadderResponse ladderResponse = JsonConvert.DeserializeObject<LadderResponse>(response);
#pragma warning restore CS8600 // Das NULL-Literal oder ein möglicher NULL-Wert wird in einen Non-Nullable-Typ konvertiert.
#pragma warning disable CS8603 // Mögliche Nullverweisrückgabe.
            return ladderResponse;
#pragma warning restore CS8603 // Mögliche Nullverweisrückgabe.
        }
    }
}
