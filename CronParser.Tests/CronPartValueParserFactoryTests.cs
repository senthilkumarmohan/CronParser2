using CronParser.CronPartValueParsers;
using CronParser.Enums;
using NUnit.Framework;
using System;

namespace CronParser.Tests
{
    [TestFixture]
    public class CronPartValueParserFactoryTests
    {
        [Test]
        public void CronPartValueParserFactory_Throws_When_ValueFormat_Is_Not_supported()
        {
            var cronPartValueParserFactory = new CronPartValueParserFactory();
            Assert.Throws(typeof(NotImplementedException),
                () => { cronPartValueParserFactory.GetCronPartValueParser((Enums.CronPartValueType)13, CronPartType.Hour); });
        }
    }
}
