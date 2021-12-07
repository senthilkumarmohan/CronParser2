using CronParser.Interfaces;
using System;
using System.Collections.Generic;

namespace CronParser
{
    public abstract class CronParserBase : ICronParser
    {
        protected readonly string CronDelimiter;
        protected readonly IMinuteParser MinuteCronPartParser;
        protected readonly IHourParser HourCronPartParser;
        protected readonly IDayOfMonthParser DayOfMonthCronPartParser;
        protected readonly IMonthParser MonthCronPartParser;
        protected readonly IDayOfWeekParser DayOfWeekCronPartParser;
        protected readonly ICommandParser CommandParser;

        public CronParserBase(
            string cronDelimiter,
            IMinuteParser minuteCronPartParser,
            IHourParser hourCronPartParser,
            IDayOfMonthParser dayOfMonthCronPartParser,
            IMonthParser monthCronPartParser,
            IDayOfWeekParser dayOfWeekCronPartParser,
            ICommandParser commandParser)
        {
            CronDelimiter = cronDelimiter;
            MinuteCronPartParser = minuteCronPartParser;
            HourCronPartParser = hourCronPartParser;
            DayOfMonthCronPartParser = dayOfMonthCronPartParser;
            MonthCronPartParser = monthCronPartParser;
            DayOfWeekCronPartParser = dayOfWeekCronPartParser;
            CommandParser = commandParser;
        }

        public abstract int ExpectedNumberOfCronParts { get; }
        public abstract bool IsValid(string[] cronParts);
        public abstract ICronParseResult Parse(string[] cronParts);

        public bool IsValid(string cronExpression)
        {
            if (string.IsNullOrWhiteSpace(cronExpression))
            {
                return false;
            }

            var cronParts = GetCronParts(cronExpression);

            if (cronParts.Length != ExpectedNumberOfCronParts)
            {
                return false;
            }

            return IsValid(cronParts);
        }

        public ICronParseResult Parse(string cronExpression)
        {
            try
            {
                if (!IsValid(cronExpression))
                {
                    throw new ArgumentException("Invalid cron expression.");
                }

                var cronParts = GetCronParts(cronExpression);

                return Parse(cronParts);
            }
            catch (Exception ex)
            {
                return new CronParseResult { Errors = new List<string> { ex.Message } };
            }
        }

        public abstract string PreProcess(string cronExpression);

        private string[] GetCronParts(string cronExpression)
        {
            cronExpression = PreProcess(cronExpression);
            return cronExpression.Split(CronDelimiter);
        }
    }
}
