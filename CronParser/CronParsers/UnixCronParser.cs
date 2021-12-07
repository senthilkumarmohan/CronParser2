using CronParser.Interfaces;
using System.Globalization;
using System.Text;

namespace CronParser
{
    public class UnixCronParser : CronParserBase
    {
        public UnixCronParser(
            IMinuteParser minuteCronPartParser,
            IHourParser hourCronPartParser,
            IDayOfMonthParser dayOfMonthCronPartParser,
            IMonthParser monthCronPartParser,
            IDayOfWeekParser dayOfWeekCronPartParser,
            ICommandParser commandParser)
            : base(Vars.UnixCronParser.CronDelimiter,
                  minuteCronPartParser,
                  hourCronPartParser,
                  dayOfMonthCronPartParser,
                  monthCronPartParser,
                  dayOfWeekCronPartParser,
                  commandParser)
        {
        }

        public override int ExpectedNumberOfCronParts { get => Vars.UnixCronParser.ExpectedNumberOfCronParts; }

        public override bool IsValid(string[] cronParts)
        {
            return MinuteCronPartParser.IsValid(cronParts[0])
                && HourCronPartParser.IsValid(cronParts[1])
                && DayOfMonthCronPartParser.IsValid(cronParts[2])
                && MonthCronPartParser.IsValid(cronParts[3])
                && DayOfWeekCronPartParser.IsValid(cronParts[4])
                && CommandParser.IsValid(cronParts[5]);
        }

        public override ICronParseResult Parse(string[] cronParts)
        {
            return new CronParseResult
            {
                Minutes = MinuteCronPartParser.GetPossibleValues(cronParts[0]),
                Hours = HourCronPartParser.GetPossibleValues(cronParts[1]),
                DayOfMonth = DayOfMonthCronPartParser.GetPossibleValues(cronParts[2]),
                Month = MonthCronPartParser.GetPossibleValues(cronParts[3]),
                DayOfWeek = DayOfWeekCronPartParser.GetPossibleValues(cronParts[4]),
                Command = cronParts[5]
            };
        }

        public override string PreProcess(string cronExpression)
        {
            var sb = new StringBuilder(cronExpression.ToLower());

            //Replace weekday names by equivalent numbers
            for (int i = 0; i < DateTimeFormatInfo.InvariantInfo.AbbreviatedDayNames.Length; i++)
            {
                sb = sb.Replace(DateTimeFormatInfo.InvariantInfo.AbbreviatedDayNames[i].ToLower(),
                    i.ToString());
            }

            //Replace month names by equivalent numbers
            for (int i = 0; i < DateTimeFormatInfo.InvariantInfo.AbbreviatedMonthNames.Length - 1; i++)
            {
                sb = sb.Replace(DateTimeFormatInfo.InvariantInfo.AbbreviatedMonthNames[i].ToLower(),
                    (i + 1).ToString());
            }

            return sb.ToString();
        }
    }
}
