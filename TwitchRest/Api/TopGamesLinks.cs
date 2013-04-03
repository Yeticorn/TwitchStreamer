namespace TwitchRest.Api
{
    public class TopGamesLinks
    {
        /// <summary>
        /// Gets or sets the url for the current page of games
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// Gets or sets the url to get the next page of games
        /// </summary>
        public string Next { get; set; }
    }
}