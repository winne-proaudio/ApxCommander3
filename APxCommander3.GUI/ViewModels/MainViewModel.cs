using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using APxCommander3.GUI.Services;
using APxCommander3.Shared;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;


namespace APxCommander3.GUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private int progress;
        private readonly ConfigurationLoader.AppSettings _settings;

        private readonly StatusWebSocketClient _webSocketClient = new();

        public MainViewModel()
        {
            _settings = ConfigurationLoader.Load();
            _ = InitializeAsync();
            if (_settings.Startup.AutoStartBackend)
            {
                BackendLauncher.EnsureBackendIsRunningAsync(_settings.Startup.BackendExePath);
            }

            /*************** WebSocket ***************/
            //_ = InitializeWebSocketAsync(_settings.Backend.WebSocketUrl);
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
        private async Task InitializeAsync()
        {
            if (_settings.Startup.AutoStartBackend)
            {
                await BackendLauncher.EnsureBackendIsRunningAsync(_settings.Startup.BackendExePath);
            }

            // Optional: WebSocket connect to _settings.Backend.WebSocketUrl
        }

        public static void StartBackendProcess(string fullExePath)
        {
            var info = new ProcessStartInfo
            {
                FileName = fullExePath,
                UseShellExecute = true
            };
            Process.Start(info);
        }
    }
}