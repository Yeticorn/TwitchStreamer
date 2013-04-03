namespace TwitchRest.Api
{
    /// <summary>
    /// Channel links
    /// </summary>
    public class ChannelLinks
    {
        /// <summary>
        /// Editors link
        /// </summary>
        public string Editors { get; set; }

        /// <summary>
        /// Stream key link
        /// </summary>
        public string StreamKey { get; set; }

        /// <summary>
        /// Commercial link
        /// </summary>
        public string Commercial { get; set; }

        /// <summary>
        /// Features link
        /// </summary>
        public string Features { get; set; }

        /// <summary>
        /// Videos link
        /// </summary>
        public string Videos { get; set; }

        /// <summary>
        /// Subscriptions link
        /// </summary>
        public string Subscriptions { get; set; }

        /// <summary>
        /// Follows link
        /// </summary>
        public string Follows { get; set; }

        /// <summary>
        /// Link to current channel
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// Chat link
        /// </summary>
        public string Chat { get; set; }
    }
}