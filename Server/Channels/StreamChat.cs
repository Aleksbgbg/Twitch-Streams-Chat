namespace Twitch.Streams.Server.Channels
{
    using WebSocketSharp;
    using WebSocketSharp.Server;

    internal class StreamChat : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Sessions.Broadcast(e.Data);
        }
    }
}