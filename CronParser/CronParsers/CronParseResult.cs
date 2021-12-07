using CronParser.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CronParser
{
    public class CronParseResult : ICronParseResult
    {
        public List<int> Minutes { get; set; }
        public List<int> Hours { get; set; }
        public List<int> DayOfMonth { get; set; }
        public List<int> Month { get; set; }
        public List<int> DayOfWeek { get; set; }
        public string Command { get; set; }
        public List<string> Errors { get; set; }

        public bool Success => Errors == null || !Errors.Any();

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Success)
            {
                sb.AppendLine($"{"minute".PadRight(14)}{string.Join(' ', Minutes)}");
                sb.AppendLine($"{"hour".PadRight(14)}{string.Join(' ', Hours)}");
                sb.AppendLine($"{"day of month".PadRight(14)}{string.Join(' ', DayOfMonth)}");
                sb.AppendLine($"{"month".PadRight(14)}{string.Join(' ', Month)}");
                sb.AppendLine($"{"day of week".PadRight(14)}{string.Join(' ', DayOfWeek)}");
                sb.AppendLine($"{"command".PadRight(14)}{Command}");
            }
            else
            {
                foreach (var error in Errors)
                {
                    sb.AppendLine(error);
                }
            }
            return sb.ToString();
        }
    }
}
