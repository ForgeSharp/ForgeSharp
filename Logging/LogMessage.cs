using System;

namespace ForgeSharp.Logging
{
    public class LogMessage
    {
        public string Time { get; set; } = DateTime.Now.ToShortTimeString();

        public string Source { get; set; } = "Anonymous";

        public string Message { get; set; }

        public LogLevel Level { get; set; } = LogLevel.Verbose;

        public bool Inline { get; set; } = false;
    }
}
