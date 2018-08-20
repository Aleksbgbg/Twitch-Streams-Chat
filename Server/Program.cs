namespace Twitch.Streams.Server
{
    using System;

    using Twitch.Streams.Server.Channels;

    using WebSocketSharp.Server;

    internal static class Program
    {
        private static void Main()
        {
            WebSocketServer webSocketServer = new WebSocketServer(Constants.Port);
            webSocketServer.AddWebSocketService<StreamChat>("/StreamChat");

            webSocketServer.Start();

            Console.WriteLine("Established server at {0} on port {1}.", webSocketServer.Address, webSocketServer.Port);
            Console.ReadKey();

            webSocketServer.Stop();
        }
    }
}