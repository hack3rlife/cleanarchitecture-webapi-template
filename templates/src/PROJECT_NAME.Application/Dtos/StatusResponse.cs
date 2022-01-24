using System;

namespace PROJECT_NAME.Application.Dtos
{
    public class StatusResponse
    {
        public string Started { get; set; }
        public string Server { get; set; }
        public string OsVersion { get; set; }
        public string AssemblyVersion { get; set; }
        public int ProcessorCount { get; set; }
        public string ElapsedTime { get; set; }
    }
}
