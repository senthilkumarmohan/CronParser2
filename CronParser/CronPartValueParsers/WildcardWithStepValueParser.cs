using CronParser.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CronParser.CronPartValueParsers
{
    public class WildcardWithStepValueParser : ICronPartValueParser
    {
        public bool IsValid(string cronPartExpression, int min, int max)
        {
            var parts = cronPartExpression.Split("/");
            return parts[0] == "*";
        }

        public List<int> GenerateValues(string cronPartExpression, int min = 0, int max = int.MaxValue)
        {
            var parts = cronPartExpression.Split("/");
            var step = int.Parse(parts[1]);

            var possibleValues = new List<int> { min };
            while (possibleValues.Last() + step <= max)
            {
                possibleValues.Add(possibleValues.Last() + step);
            }
            return possibleValues;
        }


    }
}
