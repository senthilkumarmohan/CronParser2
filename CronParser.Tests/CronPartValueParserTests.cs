using CronParser.CronPartValueParsers;
using NUnit.Framework;
using System.Linq;

namespace CronParser.Tests
{
    [TestFixture]
    public class CronPartValueParserTests
    {
        [Test]
        public void RangeValueParser_Generates_Valid_Values()
        {
            var valueParser = new RangeValueParser();
            var values = valueParser.GenerateValues("0-5");
            Assert.True(values.Count == 6 && values.Count(v => v >= 0 && v <= 5) == 6);
        }

        [Test]
        public void MultiRangeValueParser_Generates_Valid_Values()
        {
            var valueParser = new MultiRangeValueParser();
            var values = valueParser.GenerateValues("0-5, 8-9");
            Assert.True(values.Count == 8
                && values.Count(v => v >= 0 && v <= 5) == 6 && values.Count(v => v >= 8 && v <= 9) == 2);
        }

        [Test]
        public void RangeWithStepValueParser_Generates_Valid_Values()
        {
            var valueParser = new RangeWithStepValueParser();
            var values = valueParser.GenerateValues("8-17/2");
            Assert.True(values.Count == 5);
        }

        [Test]
        public void WildcardParser_Generates_Valid_Values()
        {
            var valueParser = new WildcardValueParser();
            var values = valueParser.GenerateValues("*", 0, 23);
            Assert.True(values.Count == 24);
        }

        [Test]
        public void ListValueParser_Generates_Valid_Values()
        {
            var valueParser = new ListValueParser();
            var values = valueParser.GenerateValues("1,2,3");
            Assert.True(values.Count == 3);
        }

        [Test]
        public void ConstantValueParser_Generates_Valid_Values()
        {
            var valueParser = new ListValueParser();
            var values = valueParser.GenerateValues("1");
            Assert.True(values.Count == 1);
        }
    }
}
