using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Aoe4_Overlay
{
    internal class AoeClient
    {
        private const string REQUESTURL = "https://aoeiv.net/api/leaderboard?game=aoe4";

        private readonly HttpClient httpClient;

        public AoeClient()
        {
            httpClient = new HttpClient();
        }

        public async Task<LadderResponse> GetPlayerDataAsync(string player, int mode)
        {
            HttpResponseMessage httpResponse = await httpClient.GetAsync(REQUESTURL + "&leaderboard_id=" + mode + "&search=" + player + "&count=1");
            string response = httpResponse.Content.ReadAsStringAsync().Result!;
            LadderResponse ladderResponse = JsonConvert.DeserializeObject<LadderResponse>(response!);

            return ladderResponse;
        }
    }
}
