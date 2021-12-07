using CronParser.Interfaces;

namespace CronParser.CronPartParsers
{
    public class MinuteParser : CronPartParserBase, IMinuteParser
    {
        public MinuteParser(ICronPartValueParserFactory cronPartValueParserFactory)
            : base(0, 59, Vars.RegX.Minute, cronPartValueParserFactory) { }
    }
}
