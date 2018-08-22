namespace Twitch.Streams.Server.EventArgs
{
    using System;

    internal class StreamRegisteredEventArgs : EventArgs
    {
        public StreamRegisteredEventArgs(string streamId)
        {
            StreamId = streamId;
        }

        public string StreamId { get; }
    }
}