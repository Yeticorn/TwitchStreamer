namespace TwitchRest.Api
{
    public class Stream
    {
        public string Game { get; set; }

        public int Viewers { get; set; }

        public long Id { get; set; }

        public Channel Channel { get; set; }

        public Box Preview { get; set; }

        public string Name { get; set; }

        public StreamLink Links { get; set; }

        public string Broadcaster { get; set; }
    }
}