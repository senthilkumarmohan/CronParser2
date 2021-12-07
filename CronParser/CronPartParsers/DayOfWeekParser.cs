using CronParser.Interfaces;

namespace CronParser.CronPartParsers
{
    public class DayOfWeekParser : CronPartParserBase, IDayOfWeekParser
    {
        public DayOfWeekParser(ICronPartValueParserFactory cronPartValueParserFactory)
            : base(0, 6, Vars.RegX.DayOfWeek, cronPartValueParserFactory)
        {
        }
    }
}
