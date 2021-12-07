namespace CronParser.Interfaces
{
    internal interface ICronParser
    {
        int ExpectedNumberOfCronParts { get; }
        bool IsValid(string cronExpression);
        bool IsValid(string[] cronParts);
        string PreProcess(string cronExpression);
        ICronParseResult Parse(string cronExpression);
        ICronParseResult Parse(string[] cronParts);
    }
}
