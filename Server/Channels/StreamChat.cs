namespace Twitch.Streams.Server.Channels
{
    using System;

    using WebSocketSharp;
    using WebSocketSharp.Server;

    internal class StreamChat : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            Sessions.Broadcast("User joined.");
            Console.WriteLine("User joined.");
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            Sessions.Broadcast(e.Data);
            Console.WriteLine("User says: {0}", e.Data);
        }

        protected override void OnClose(CloseEventArgs e)
        {
            Sessions.Broadcast("User left.");
            Console.WriteLine("User left.");
        }
    }
}