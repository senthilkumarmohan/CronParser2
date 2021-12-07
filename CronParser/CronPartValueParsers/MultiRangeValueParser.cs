using CronParser.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CronParser.CronPartValueParsers
{
    public class MultiRangeValueParser : ICronPartValueParser
    {
        public bool IsValid(string cronPartExpression, int min, int max)
        {
            var ranges = cronPartExpression.Split(",");
            foreach (var range in ranges)
            {
                var parts = range.Split('-');
                var start = int.Parse(parts[0]);
                var end = int.Parse(parts[1]);
                if (start > end)
                {
                    return false;
                }
            }
            return true;
        }

        public List<int> GenerateValues(string cronPartExpression, int min = 0, int max = int.MaxValue)
        {
            var ranges = cronPartExpression.Split(",");
            var values = new List<int>();
            foreach (var range in ranges)
            {
                var parts = range.Split("-");
                var start = int.Parse(parts[0]);
                var end = int.Parse(parts[1]);
                if (!values.Contains(start))
                {
                    values.Add(start);
                }
                while (values.Last() + 1 <= end)
                {
                    if (!values.Contains(values.Last() + 1))
                    {
                        values.Add(values.Last() + 1);
                    }
                }
            }
            return values;
        }
    }
}
