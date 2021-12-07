using CronParser.Enums;

namespace CronParser.Interfaces
{
    public interface ICronPartValueParserFactory
    {
        ICronPartValueParser GetCronPartValueParser(string cronPart, CronPartType cronPartType);
        ICronPartValueParser GetCronPartValueParser(CronPartValueType cronPartValueType, CronPartType cronPartType);
    }
}