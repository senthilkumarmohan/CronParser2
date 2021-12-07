using CronParser.Enums;
using System;
using System.Text.RegularExpressions;

namespace CronParser
{
    public static class CronPartExtensions
    {
        public static CronPartValueType GetCronPartValueType(this string cronPart, CronPartType cronPartType)
        {
            if (Regex.IsMatch(cronPart, Vars.RegX.Constant))
            {
                return CronPartValueType.Constant;
            }
            if (Regex.IsMatch(cronPart, Vars.RegX.List))
            {
                return CronPartValueType.List;
            }
            if (Regex.IsMatch(cronPart, Vars.RegX.Range))
            {
                if(cronPartType == CronPartType.DayOfWeek)
                {
                    var isOverLappingRange = IsOverLappingRange(cronPart);
                    if (isOverLappingRange)
                    {
                        return CronPartValueType.OverLappingRange;
                    }
                    else
                    {
                        return CronPartValueType.Range;
                    }
                }
                return CronPartValueType.Range;
            }
            if (Regex.IsMatch(cronPart, Vars.RegX.RangeWithStep))
            {
                return CronPartValueType.RangeWithStep;
            }
            if (Regex.IsMatch(cronPart, Vars.RegX.MultiRange))
            {
                return CronPartValueType.MultiRange;
            }
            if (Regex.IsMatch(cronPart, Vars.RegX.Wildcard))
            {
                return CronPartValueType.Wildcard;
            }
            if (Regex.IsMatch(cronPart, Vars.RegX.WildcardWithStep))
            {
                return CronPartValueType.WildcardWithStep;
            }

            throw new NotImplementedException("Unknown cron part value type");
        }

        private static bool IsOverLappingRange(string cronPart)
        {
            var parts = cronPart.Split('-');
            var start = int.Parse(parts[0]);
            var end = int.Parse(parts[1]);
            var isOverLappingRange = start > end;
            return isOverLappingRange;
        }
    }
}
