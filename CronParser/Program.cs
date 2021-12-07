using CronParser.CronPartParsers;
using CronParser.CronPartValueParsers;
using System;
using System.Linq;

namespace CronParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cronExpression = args.FirstOrDefault();
            var cronParser = BuildCronParser();
            Console.WriteLine(Environment.NewLine + cronParser.Parse(cronExpression));
        }

        private static UnixCronParser BuildCronParser()
        {
            var cronPartValueParserFactory = new CronPartValueParserFactory();
            return new UnixCronParser(
                new MinuteParser(cronPartValueParserFactory),
                new HourParser(cronPartValueParserFactory),
                new DayOfMonthParser(cronPartValueParserFactory),
                new MonthParser(cronPartValueParserFactory),
                new DayOfWeekParser(cronPartValueParserFactory),
                new CommandParser(cronPartValueParserFactory));
        }
    }
}
