namespace TwitchRest.Api
{
    /// <summary>
    /// Represents an error response
    /// </summary>
    public class RestError
    {
        /// <summary>
        /// Gets or sets the error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the error
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets the status code
        /// </summary>
        public int Status { get; set; }
    }
}