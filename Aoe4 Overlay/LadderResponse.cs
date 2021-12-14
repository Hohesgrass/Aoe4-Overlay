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
        private const string REQUESTURL = "https://aoeiv.net/api/leaderboard?game=aoe4";

        public List<Leaderboard> Leaderboard;
    }
}
