namespace TwitchRest.Api
{
    public class TopGame
    {
        /// <summary>
        /// Gets or sets the game
        /// </summary>
        public Game Game { get; set; }

        /// <summary>
        /// Gets or sets the number of viewers
        /// </summary>
        public int Viewers { get; set; }

        /// <summary>
        /// Gets or sets the number of channels
        /// </summary>
        public int Channels { get; set; }
    }
}