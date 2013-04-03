using RestSharp.Serializers;

namespace TwitchRest.Api
{
    public class Game
    {
        /// <summary>
        /// Gets or sets the name of the game
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets box art
        /// </summary>
        public Box Box { get; set; }

        /// <summary>
        /// Gets or sets logo art
        /// </summary>
        public Box Logo { get; set; }

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the giant bomb ID
        /// </summary>
        [SerializeAs( Name = "giantbomb_id" )]
        public long GiantbombId { get; set; }
    }
}