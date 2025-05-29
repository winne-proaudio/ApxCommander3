using Fleck;
using APxCommander3.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace APxCommander3.Backend
{
    public static class WebSocketHost
    {
        private static List<IWebSocketConnection> _clients = new List<IWebSocketConnection>();

        public static void Start()
        {
            FleckLog.Level = LogLevel.Info;
            var server = new WebSocketServer("ws://0.0.0.0:5001");

            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    Console.WriteLine("WebSocket verbunden");
                    _clients.Add(socket);
                };

                socket.OnClose = () =>
                {
                    Console.WriteLine("WebSocket getrennt");
                    _clients.Remove(socket);
                };

                socket.OnMessage = message =>
                {
                    Console.WriteLine("Nachricht erhalten: " + message);
                };
            });
        }

        public static void PushStatus(StatusUpdate update)
        {
            string json = JsonConvert.SerializeObject(update);
            foreach (var client in _clients)
            {
                client.Send(json);
            }
        }
    }
}