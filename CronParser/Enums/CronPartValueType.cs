namespace CronParser.Enums
{
    public enum CronPartValueType
    {
        Constant = 1,
        List,
        Range,
        OverLappingRange,
        MultiRange,
        RangeWithStep,
        Wildcard,
        WildcardWithStep
    }
}
