using CronParser.Enums;
using CronParser.Interfaces;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CronParser.CronPartParsers
{
    public abstract class CronPartParserBase : ICronPartParser
    {
        private readonly ICronPartValueParserFactory _cronPartValueParserFactory;

        public int Minimum { get; }

        public int Maximum { get; }

        public string ValidationRegEx { get; }

        public abstract CronPartType PartType { get; }

        public CronPartParserBase(int min, int max, string validationRegEx,
            ICronPartValueParserFactory cronPartValueParserFactory)
        {
            Minimum = min;
            Maximum = max;
            ValidationRegEx = validationRegEx;
            _cronPartValueParserFactory = cronPartValueParserFactory;
        }

        public virtual bool IsValid(string cronPart)
        {
            var isValid = Regex.IsMatch(cronPart, ValidationRegEx);
            if (isValid)
            {
                var cronPartValueParser = _cronPartValueParserFactory.GetCronPartValueParser(cronPart, PartType);
                isValid = isValid && cronPartValueParser.IsValid(cronPart, Minimum, Maximum);
            }
            return isValid;
        }

        public List<int> GetPossibleValues(string cronPart)
        {
            var cronPartValueParser = _cronPartValueParserFactory.GetCronPartValueParser(cronPart, PartType);
            return cronPartValueParser.GenerateValues(cronPart, Minimum, Maximum);
        }
    }
}
