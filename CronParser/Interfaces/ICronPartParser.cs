using CronParser.Enums;
using System.Collections.Generic;

namespace CronParser.Interfaces
{
    public interface ICronPartParser
    {
        CronPartType PartType { get; }
        int Minimum { get; }
        int Maximum { get; }
        string ValidationRegEx { get; }
        bool IsValid(string cronPart);
        List<int> GetPossibleValues(string cronPart);
    }
}
