namespace APxCommander3.Shared
{
    public class StatusUpdate
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public int? ProgressPercent { get; set; }
        public string CurrentStep { get; set; }
    }
}