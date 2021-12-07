using CronParser.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CronParser.CronPartValueParsers
{
    public class WildcardValueParser : ICronPartValueParser
    {
        public bool IsValid(string cronPartExpression, int min, int max)
        {
            return cronPartExpression == "*";
        }

        public List<int> GenerateValues(string cronPartExpression, int min = 0, int max = int.MaxValue)
        {
            var possibleValues = new List<int> { min };
            while (possibleValues.Last() + 1 <= max)
            {
                possibleValues.Add(possibleValues.Last() + 1);
            }
            return possibleValues;
        }
    }
}