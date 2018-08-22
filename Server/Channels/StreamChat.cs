namespace Twitch.Streams.Server.Channels
{
    using System;

    using Newtonsoft.Json;

    using Twitch.Streams.Server.Models;

    using WebSocketSharp;
    using WebSocketSharp.Server;

    internal class StreamChat : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Sessions.Broadcast(e.Data);

            Message receivedMessage = JsonConvert.DeserializeObject<Message>(e.Data);
            Console.WriteLine("{0}: {1}", receivedMessage.Sender, receivedMessage.Content);
        }
    }
}