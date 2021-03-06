﻿namespace Twitch.Streams.Server.Channels
{
    using System;

    using Newtonsoft.Json;

    using Twitch.Streams.Server.Models;

    using WebSocketSharp;
    using WebSocketSharp.Server;

    internal class PersonalChat : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            UpdateUserCount();
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            Sessions.Broadcast(e.Data);

            Message receivedMessage = JsonConvert.DeserializeObject<Message>(e.Data);
            Console.WriteLine("{0}: {1}", receivedMessage.Sender, receivedMessage.Content);
        }

        protected override void OnClose(CloseEventArgs e)
        {
            UpdateUserCount();
        }

        private void UpdateUserCount()
        {
            Sessions.Broadcast(Sessions.Count.ToString());
        }
    }
}