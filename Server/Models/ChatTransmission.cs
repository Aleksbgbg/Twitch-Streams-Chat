namespace Twitch.Streams.Server.Models
{
    using Newtonsoft.Json;

    internal class ChatTransmission
    {
        [JsonConstructor]
        public ChatTransmission(OpCode opCode, Message message)
        {
            OpCode = opCode;
            Message = message;
        }

        [JsonProperty("OpCode")]
        public OpCode OpCode { get; }

        [JsonProperty("Message")]
        public Message Message { get; }
    }
}