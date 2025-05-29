using System.Collections.Generic;

namespace APxCommander3.Shared
{
    public class CommandRequest
    {
        public string Action { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }
}