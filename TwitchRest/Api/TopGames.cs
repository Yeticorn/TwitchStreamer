using System.Collections.Generic;

namespace TwitchRest.Api
{
    public class TopGames
    {
        public TopGamesLinks Links { get; set; }

        public List<TopGame> Top { get; set; }

        public int Total { get; set; }
    }
}
