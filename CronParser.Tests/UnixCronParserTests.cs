using CronParser.CronPartParsers;
using CronParser.CronPartValueParsers;
using NUnit.Framework;

namespace CronParser.Tests
{
    public class UnixCronParserTests
    {
        [Test]
        public void Validation_Fails_When_Empty_Cron_Provided()
        {
            var unixCronParser = BuildCronParser();
            var result = unixCronParser.IsValid("");
            Assert.IsFalse(result);
        }

        [Test]
        public void Validation_Fails_When_Invalid_Number_Of_CronParts_Provided()
        {
            var unixCronParser = BuildCronParser();
            var result = unixCronParser.IsValid("* *");
            Assert.IsFalse(result);
        }

        [Test]
        public void Validation_Fails_When_Command_Is_Not_Provided()
        {
            var unixCronParser = BuildCronParser();
            var result = unixCronParser.IsValid("*/15 0 1,15 * 1-5");
            Assert.IsFalse(result);
        }

        [Test]
        public void Validation_Fails_When_Range_Is_Invalid()
        {
            var unixCronParser = BuildCronParser();
            var result = unixCronParser.IsValid("*/15 0 1,15 * 5-1");
            Assert.IsFalse(result);
        }

        [Test]
        public void Validation_Passes_When_Valid_Cron_Provided()
        {
            var unixCronParser = BuildCronParser();
            var result = unixCronParser.IsValid("*/15 0 1,15 * 1-5 /usr/bin/find");
            Assert.True(result);
        }

        [Test]
        public void Validation_Passes_When_Valid_Cron_With_WeekDay_Names_Provided()
        {
            var unixCronParser = BuildCronParser();
            var result = unixCronParser.IsValid("*/15 0 1,15 * mon-fri /usr/bin/find");
            Assert.True(result);
        }

        [Test]
        public void Validation_Passes_When_Valid_Cron_With_Month_Names_Provided()
        {
            var unixCronParser = BuildCronParser();
            var result = unixCronParser.IsValid("*/15 0 1,15 jan,jul 1-5 /usr/bin/find");
            Assert.True(result);
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
