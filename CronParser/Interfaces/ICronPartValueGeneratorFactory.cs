using CronParser.Enums;

namespace CronParser.Interfaces
{
    public interface ICronPartValueParserFactory
    {
        ICronPartValueParser GetCronPartValueParser(string cronPart);
        ICronPartValueParser GetCronPartValueParser(CronPartValueType cronPartValueType);
    }
}