# APxCommander3

APxCommander3 ist ein hybrides Windows-basiertes Steuer- und Visualisierungssystem für Audio-Messungen mit Audio Precision (APx). Es besteht aus zwei Teilen:

- 🧠 **Backend** (`APxCommander3.Backend`): Startet und steuert APx-Projekte, verarbeitet Messungen und stellt eine HTTP- sowie WebSocket-Schnittstelle bereit.
- 🖥 **GUI** (`APxCommander3.GUI`): Cross-Plattform-GUI auf Basis von Avalonia UI (.NET 8), die den Messablauf visuell darstellt, steuert und Statusmeldungen empfängt.

## 🔧 Projektstruktur

APxCommander3/
├── APxCommander3.Backend # .NET Framework 4.8 – APx-Steuerung, REST + WebSocket
├── APxCommander3.GUI # .NET 8 – Avalonia Frontend mit MVVM
├── APxCommander3.Shared # .NET Standard 2.0 – Gemeinsame DTOs & Modelle
└── README.md # Diese Datei


## 🚀 Funktionsweise

- Die GUI sendet Kommandos an das Backend über REST (`/api/command`)
- Das Backend führt Messungen durch und meldet Status/Ereignisse über WebSocket (`ws://localhost:5001`)
- Ergebnisse und Fehler werden visuell in der GUI dargestellt

## ⚙️ Konfiguration (`appsettings.json`)

```json
{
  "Backend": {
    "RestUrl": "http://localhost:5000/api",
    "WebSocketUrl": "ws://localhost:5001"
  },
  "Startup": {
    "AutoStartBackend": true,
    "BackendExePath": "C:\\\\APxCommander3\\\\APxCommander3.Backend.exe"
  }
}
🧪 Voraussetzungen

Windows 10 oder höher (für Backend mit APx SDK)
.NET Framework 4.8 (Backend)
.NET 8 SDK (GUI)
Visual Studio oder JetBrains Rider
📦 NuGet-Abhängigkeiten (Auswahl)

GUI:

Avalonia 11.3.0
CommunityToolkit.Mvvm 8.4.0
MessageBox.Avalonia
Newtonsoft.Json
Backend:

Microsoft.Owin.Hosting
Microsoft.AspNet.WebApi.OwinSelfHost
Fleck (WebSocket)
Newtonsoft.Json
🛠 Startanleitung (lokal)

Backend bauen und bereitstellen (Windows-only)
GUI starten (auf Windows oder macOS möglich)
REST/WS-Verbindung wird automatisch aufgebaut
GUI zeigt Fortschritt und Ereignisse live an
📝 TODO

 Logging in Datei oder Konsole
 Authentifizierung (optional)
 Setup-Skript für Deployment
 Status-Log in GUI
👤 Autor

Winne ProAudio
Projekt für Audio Precision Automatisierung & Visualisierung

🧾 Lizenz


