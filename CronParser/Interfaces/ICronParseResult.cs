using System.Collections.Generic;

namespace CronParser.Interfaces
{
    public interface ICronParseResult
    {
        List<int> DayOfWeek { get; set; }
        List<int> Hours { get; set; }
        List<int> Minutes { get; set; }
        List<int> Month { get; set; }
        List<int> DayOfMonth { get; set; }
        public string Command { get; set; }
        public List<string> Errors { get; set; }
        public bool Success { get; }
    }
}