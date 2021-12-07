using CronParser.Enums;
using CronParser.Interfaces;

namespace CronParser.CronPartParsers
{
    public class HourParser : CronPartParserBase, IHourParser
    {
        public HourParser(ICronPartValueParserFactory cronPartValueParserFactory)
            : base(0, 23, Vars.RegX.Hour, cronPartValueParserFactory) { }

        public override CronPartType PartType => CronPartType.Hour;
    }
}
