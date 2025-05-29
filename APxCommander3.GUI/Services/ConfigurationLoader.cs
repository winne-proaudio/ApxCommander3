using Newtonsoft.Json;
using System.IO;

public static class ConfigurationLoader
{
    public class AppSettings
    {
        public BackendSettings Backend { get; set; }
        public StartupSettings Startup { get; set; }
    }

    public class BackendSettings
    {
        public string RestUrl { get; set; }
        public string WebSocketUrl { get; set; }
    }

    public class StartupSettings
    {
        public bool AutoStartBackend { get; set; }
        public string BackendExePath { get; set; }
    }
    public static AppSettings Load(string path = "appsettings.json")
    {
        var json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<AppSettings>(json);
    }
}