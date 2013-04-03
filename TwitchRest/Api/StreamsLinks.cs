namespace TwitchRest.Api
{
    public class StreamsLinks
    {
        /// <summary>
        /// Gets or sets the url for the current page of streams
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// Gets or sets the url to get the next page of streams
        /// </summary>
        public string Next { get; set; }
    }
}