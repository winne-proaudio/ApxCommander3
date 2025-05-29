using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System;

public static class BackendLauncher
{
    private const string HealthUrl = "http://localhost:5000/api/health";

    public static async Task EnsureBackendIsRunningAsync(string backendExePath)
    {
        if (!await IsBackendRunningAsync())
        {
            Console.WriteLine("Backend läuft nicht – wird gestartet...");
            StartBackendProcess(backendExePath);
            await WaitForBackendAsync();
        }
    }

    private static async Task<bool> IsBackendRunningAsync()
    {
        try
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(HealthUrl);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    private static void StartBackendProcess(string fullExePath)
    {
        var info = new ProcessStartInfo
        {
            FileName = fullExePath,
            UseShellExecute = true
        };
        Process.Start(info);
    }

    private static async Task WaitForBackendAsync()
    {
        for (int i = 0; i < 10; i++)
        {
            if (await IsBackendRunningAsync())
                return;

            await Task.Delay(500);
        }

        throw new Exception("Backend konnte nicht gestartet werden.");
    }
}