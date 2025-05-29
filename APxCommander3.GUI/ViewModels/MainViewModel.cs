using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using APxCommander3.Shared;
using APxCommander3.GUI.Services;
using System.Threading.Tasks;

namespace APxCommander3.GUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
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