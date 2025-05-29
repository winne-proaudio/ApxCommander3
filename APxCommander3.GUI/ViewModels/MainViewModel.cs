using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using APxCommander3.GUI.Services;
using APxCommander3.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APxCommander3.GUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private int progress;

        private readonly StatusWebSocketClient _webSocketClient = new();

        public MainViewModel()
        {
            _webSocketClient.OnStatusReceived += HandleStatusUpdate;
            _ = _webSocketClient.ConnectAsync();
        }

        private void HandleStatusUpdate(StatusUpdate update)
        {
            if (update.Type == "Progress" && update.ProgressPercent.HasValue)
            {
                Progress = update.ProgressPercent.Value;
            }
        }

        [RelayCommand]
        private async Task StartMeasurement()
        {
            var command = new CommandRequest
            {
                Action = "StartMeasurement",
                Parameters = new Dictionary<string, string>
                {
                    { "profile", "StandardAPTest" }
                }
            };

            await RestClient.SendCommandAsync(command);
        }
    }
}