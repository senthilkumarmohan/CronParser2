using System.Collections.Generic;

namespace CronParser.Interfaces
{
    public interface ICronPartValueParser
    {
        bool IsValid(string cronPartExpression, int min, int max);
        List<int> GenerateValues(string cronPartExpression, int min = 0, int max = int.MaxValue);
    }
}
