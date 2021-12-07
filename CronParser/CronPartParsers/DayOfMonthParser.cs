using CronParser.Interfaces;

namespace CronParser.CronPartParsers
{
    public class DayOfMonthParser : CronPartParserBase, IDayOfMonthParser
    {
        public DayOfMonthParser(ICronPartValueParserFactory cronPartValueParserFactory)
            : base(1, 31, Vars.RegX.DayOfMonth, cronPartValueParserFactory) { }
    }
}
