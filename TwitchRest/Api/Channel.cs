using System;
using System.Collections.Generic;

namespace TwitchRest.Api
{
    public class Channel
    {
        public string Game { get; set; }

        public string DisplayName { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Status { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool? Mature { get; set; } // example just had null; not sure what data type is suppose to be

        public long Id { get; set; }

        public string VideoBanner { get; set; }

        public string Name { get; set; }

        public string Banner { get; set; }

        public string Background { get; set; } // again, just had null

        public ChannelLinks Links { get; set; }

        public List<String> Teams { get; set; } // example just has empty array

        public string Logo { get; set; }

        public string Url { get; set; }
    }
}