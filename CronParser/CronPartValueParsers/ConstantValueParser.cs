using CronParser.Interfaces;
using System.Collections.Generic;

namespace CronParser.CronPartValueParsers
{
    public class ConstantValueParser : ICronPartValueParser
    {
        public bool IsValid(string cronPartExpression, int min, int max)
        {
            var value = int.Parse(cronPartExpression);
            return value >= min && value <= max;
        }

        public List<int> GenerateValues(string cronPartExpression, int min = 0, int max = int.MaxValue)
        {
            return new List<int> { int.Parse(cronPartExpression) };
        }
    }
}