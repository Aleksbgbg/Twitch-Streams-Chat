namespace Twitch.Streams.Server.Channels
{
    using System;

    using Twitch.Streams.Server.EventArgs;

    using WebSocketSharp;
    using WebSocketSharp.Server;

    internal class RegisterStream : WebSocketBehavior
    {
        internal event EventHandler<StreamRegisteredEventArgs> StreamRegistered;

        protected override void OnMessage(MessageEventArgs e)
        {
            StreamRegistered?.Invoke(this, new StreamRegisteredEventArgs(e.Data));
        }
    }
}