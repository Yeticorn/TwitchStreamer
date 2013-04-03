namespace TwitchRest.Api
{
    public class Box
    {
        /// <summary>
        /// Gets or sets the large box art image URL
        /// </summary>
        public string Large { get; set; }

        /// <summary>
        /// Gets or sets the medium box art image URL
        /// </summary>
        public string Medium { get; set; }

        /// <summary>
        /// Gets or sets the small box art image URL
        /// </summary>
        public string Small { get; set; }

        /// <summary>
        /// Gets or sets the box art template
        /// </summary>
        public string Template { get; set; }
    }
}
