using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APxCommander3.Shared;
using Newtonsoft.Json;

namespace APxCommander3.GUI.Services
{
    public class StatusWebSocketClient
    {
        private ClientWebSocket _webSocket;

        public event Action<StatusUpdate> OnStatusReceived;

        public async Task ConnectAsync()
        {
            _webSocket = new ClientWebSocket();
            await _webSocket.ConnectAsync(new Uri("ws://localhost:5001"), CancellationToken.None);
            _ = ReceiveLoop();
        }

        private async Task ReceiveLoop()
        {
            var buffer = new byte[4096];

            while (_webSocket.State == WebSocketState.Open)
            {
                var result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                var update = JsonConvert.DeserializeObject<StatusUpdate>(message);
                OnStatusReceived?.Invoke(update);
            }
        }
    }
}