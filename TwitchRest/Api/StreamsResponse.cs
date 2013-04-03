using System.Collections.Generic;

namespace TwitchRest.Api
{
    public class StreamsResponse
    {
        public StreamsLinks Links { get; set; }

        public List<Stream> Streams { get; set; }
    }
}