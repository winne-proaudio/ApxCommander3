using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using APxCommander3.Shared;
using Newtonsoft.Json;

namespace APxCommander3.Backend.Api
{
    public static class StatusPushService
    {
        private static readonly List<WebSocket> Clients = new List<WebSocket>();

        public static void RegisterClient(WebSocket socket)
        {
            lock (Clients) Clients.Add(socket);
        }

        public static async void SendToAll(StatusUpdate update)
        {
            string json = JsonConvert.SerializeObject(update);
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            var segment = new ArraySegment<byte>(buffer);

            lock (Clients)
            {
                foreach (var client in Clients.ToArray())
                {
                    if (client.State == WebSocketState.Open)
                    {
                        _ = client.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                }
            }
        }
    }
}