using CronParser.Enums;
using CronParser.Interfaces;

namespace CronParser.CronPartParsers
{
    public class DayOfWeekParser : CronPartParserBase, IDayOfWeekParser
    {
        public DayOfWeekParser(ICronPartValueParserFactory cronPartValueParserFactory)
            : base(0, 6, Vars.RegX.DayOfWeek, cronPartValueParserFactory)
        {
        }

        public override CronPartType PartType => CronPartType.DayOfWeek;
    }
}
