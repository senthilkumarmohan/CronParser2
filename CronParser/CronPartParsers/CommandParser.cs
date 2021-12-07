using CronParser.Enums;
using CronParser.Interfaces;
using System.Text.RegularExpressions;

namespace CronParser.CronPartParsers
{
    public class CommandParser : CronPartParserBase, ICommandParser
    {
        public CommandParser(ICronPartValueParserFactory cronPartValueParserFactory)
            : base(1, 100, Vars.RegX.Command, cronPartValueParserFactory)
        {
        }

        public override CronPartType PartType => throw new System.NotImplementedException();

        public override bool IsValid(string cronPart)
        {
            return Regex.IsMatch(cronPart, ValidationRegEx);
        }
    }
}
