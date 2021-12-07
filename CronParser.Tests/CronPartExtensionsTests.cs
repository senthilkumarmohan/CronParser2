using CronParser.Enums;
using NUnit.Framework;
using System;

namespace CronParser.Tests
{
    [TestFixture]
    public class CronPartExtensionsTests
    {
        [Test]
        public void RangeValueType_Identified_Correctly()
        {
            Assert.True("5-8".GetCronPartValueType() == CronPartValueType.Range);
        }

        [Test]
        public void ListValueType_Identified_Correctly()
        {
            Assert.True("5,8,9".GetCronPartValueType() == CronPartValueType.List);
        }

        [Test]
        public void MultiRangeValueType_Identified_Correctly()
        {
            Assert.True("1-3,5-8".GetCronPartValueType() == CronPartValueType.MultiRange);
        }

        [Test]
        public void RangeWithStepValueType_Identified_Correctly()
        {
            Assert.True("5-17/2".GetCronPartValueType() == CronPartValueType.RangeWithStep);
        }

        [Test]
        public void WildcardValueType_Identified_Correctly()
        {
            Assert.True("*".GetCronPartValueType() == CronPartValueType.Wildcard);
        }

        [Test]
        public void WildcardWithStepValueType_Identified_Correctly()
        {
            Assert.True("*/5".GetCronPartValueType() == CronPartValueType.WildcardWithStep);
        }

        [Test]
        public void Throws_When_ValueType_Not_Supported()
        {
            Assert.Throws(typeof(NotImplementedException), () => { "7/8".GetCronPartValueType(); });
        }
    }
}
