using System.Collections.Generic;

namespace CronParser.Interfaces
{
    public interface IConstantParser : ICronPartParser
    {
        List<int> GetPossibleValuesFromConstant(int constant);
    }
}
