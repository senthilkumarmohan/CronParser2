using CronParser.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CronParser.CronPartValueParsers
{
    public class RangeWithStepValueParser : ICronPartValueParser
    {
        public bool IsValid(string cronPartExpression, int min, int max)
        {
            var parts = cronPartExpression.Split(new char[] { '-', '/' });
            var start = int.Parse(parts[0]);
            var end = int.Parse(parts[1]);
            var step = int.Parse(parts[2]);
            return min <= start && start <= end && end <= max;
        }

        public List<int> GenerateValues(string cronPartExpression, int min = 0, int max = int.MaxValue)
        {
            var parts = cronPartExpression.Split(new char[] { '-', '/' });
            var start = int.Parse(parts[0]);
            var end = int.Parse(parts[1]);
            var step = int.Parse(parts[2]);

            var possibleValues = new List<int> { start };
            while (possibleValues.Last() + step <= end)
            {
                possibleValues.Add(possibleValues.Last() + step);
            }
            return possibleValues;
        }
    }
}