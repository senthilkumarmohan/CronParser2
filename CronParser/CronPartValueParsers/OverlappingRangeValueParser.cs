using CronParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CronParser.CronPartValueParsers
{
    public class OverlappingRangeValueParser : ICronPartValueParser
    {
        public bool IsValid(string cronPartExpression, int min, int max)
        {
            var parts = cronPartExpression.Split('-');
            var start = int.Parse(parts[0]);
            var end = int.Parse(parts[1]);
            return max > start && start > end && end > min;
        }

        public List<int> GenerateValues(string cronPartExpression, int min = 0, int max = int.MaxValue)
        {
            var parts = cronPartExpression.Split('-');
            var start = int.Parse(parts[0]);
            var end = int.Parse(parts[1]);

            var possibleValues = new List<int> { start };
            var counter = start;
            while (counter + 1 <= max + end + 1)
            {
                possibleValues.Add((counter + 1) % (max + 1));
                counter++;
            }
            return possibleValues;
        }
    }
}
