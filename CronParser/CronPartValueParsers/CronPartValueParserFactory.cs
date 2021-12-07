using CronParser.Enums;
using CronParser.Interfaces;
using System;

namespace CronParser.CronPartValueParsers
{
    public class CronPartValueParserFactory : ICronPartValueParserFactory
    {
        public ICronPartValueParser GetCronPartValueParser(string cronPart)
        {
            var cronPartValueType = cronPart.GetCronPartValueType();
            return GetCronPartValueParser(cronPartValueType);
        }

        public ICronPartValueParser GetCronPartValueParser(CronPartValueType cronPartValueType)
        {
            switch (cronPartValueType)
            {
                case CronPartValueType.Constant:
                    return new ConstantValueParser();
                case CronPartValueType.List:
                    return new ListValueParser();
                case CronPartValueType.Range:
                    return new RangeValueParser();
                case CronPartValueType.MultiRange:
                    return new MultiRangeValueParser();
                case CronPartValueType.RangeWithStep:
                    return new RangeWithStepValueParser();
                case CronPartValueType.Wildcard:
                    return new WildcardValueParser();
                case CronPartValueType.WildcardWithStep:
                    return new WildcardWithStepValueParser();
                default:
                    throw new NotImplementedException("Unknown cron part value type");
            }
        }
    }
}
