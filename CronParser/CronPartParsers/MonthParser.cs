using CronParser.Enums;
using CronParser.Interfaces;

namespace CronParser.CronPartParsers
{
    public class MonthParser : CronPartParserBase, IMonthParser
    {
        public MonthParser(ICronPartValueParserFactory cronPartValueParserFactory)
            : base(1, 12, Vars.RegX.Month, cronPartValueParserFactory) { }

        public override CronPartType PartType => CronPartType.Month;
    }
}
