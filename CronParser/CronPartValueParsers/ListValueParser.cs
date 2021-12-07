using CronParser.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CronParser.CronPartValueParsers
{
    public class ListValueParser : ICronPartValueParser
    {
        public bool IsValid(string cronPartExpression, int min, int max)
        {
            return cronPartExpression.Split(",").Select(s => int.Parse(s))
                .All(value => value >= min && value <= max);
        }

        public List<int> GenerateValues(string cronPartExpression, int min = 0, int max = int.MaxValue)
        {
            return cronPartExpression.Split(",").Select(s => int.Parse(s)).ToList();
        }
    }
}