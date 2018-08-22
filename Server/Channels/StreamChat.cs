namespace Twitch.Streams.Server.Channels
{
    using System;

    using Newtonsoft.Json;

    using Twitch.Streams.Server.Models;

    using WebSocketSharp;
    using WebSocketSharp.Server;

    internal class StreamChat : WebSocketBehavior
    {
        internal event EventHandler ServiceClosed;

        protected override void OnMessage(MessageEventArgs e)
        {
            Sessions.Broadcast(e.Data);

            Message receivedMessage = JsonConvert.DeserializeObject<Message>(e.Data);
            Console.WriteLine("{0}: {1}", receivedMessage.Sender, receivedMessage.Content);
        }

        protected override void OnClose(CloseEventArgs e)
        {
            if (Sessions.Count == 0)
            {
                OnServiceClosed();
            }
        }

        protected override void OnError(ErrorEventArgs e)
        {
            OnServiceClosed();
        }

        private void OnServiceClosed()
        {
            ServiceClosed?.Invoke(this, EventArgs.Empty);
        }
    }
}