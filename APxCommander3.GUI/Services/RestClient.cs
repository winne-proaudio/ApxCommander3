using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using APxCommander3.Shared;
using Newtonsoft.Json;

namespace APxCommander3.GUI.Services
{
    public static class RestClient
    {
        private static readonly HttpClient Client = new();

        public static async Task SendCommandAsync(CommandRequest command)
        {
            var json = JsonConvert.SerializeObject(command);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await Client.PostAsync("http://localhost:5000/api/command", content);
        }
    }
}