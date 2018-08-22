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

            {
                RegisterStream RegisterStreamFactory()
                {
                    RegisterStream registerStream = new RegisterStream();

                    registerStream.StreamRegistered += (sender, e) =>
                    {
                        StreamChat StreamChatFactory()
                        {
                            StreamChat streamChat = new StreamChat();

                            streamChat.ServiceClosed += (sender2, _) => webSocketServer.RemoveWebSocketService($"/StreamChat/{e.StreamId}");

                            return streamChat;
                        }

                        webSocketServer.AddWebSocketService($"/StreamChat/{e.StreamId}", StreamChatFactory);
                    };

                    return registerStream;
                }

                webSocketServer.AddWebSocketService("/RegisterStream", RegisterStreamFactory);
            }

            webSocketServer.Start();

            Console.WriteLine("Established server at {0} on port {1}.", webSocketServer.Address, webSocketServer.Port);
            Console.ReadKey();

            webSocketServer.Stop();
        }
    }
}