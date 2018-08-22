namespace Twitch.Streams.Server.Models
{
    using Newtonsoft.Json;

    internal class Message
    {
        [JsonConstructor]
        public Message(string sender, string content)
        {
            Sender = sender;
            Content = content;
        }

        [JsonProperty("Sender")]
        public string Sender { get; }

        [JsonProperty("Content")]
        public string Content { get; }
    }
}