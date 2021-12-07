using CronParser.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CronParser.CronPartValueParsers
{
    public class RangeValueParser : ICronPartValueParser
    {
        public bool IsValid(string cronPartExpression, int min, int max)
        {
            var parts = cronPartExpression.Split('-');
            var start = int.Parse(parts[0]);
            var end = int.Parse(parts[1]);
            return min <= start && start <= end && end <= max;
        }

        public List<int> GenerateValues(string cronPartExpression, int min = 0, int max = int.MaxValue)
        {
            var parts = cronPartExpression.Split('-');
            var start = int.Parse(parts[0]);
            var end = int.Parse(parts[1]);

            var possibleValues = new List<int> { start };
            while (possibleValues.Last() + 1 <= end)
            {
                possibleValues.Add(possibleValues.Last() + 1);
            }
            return possibleValues;
        }
    }
}