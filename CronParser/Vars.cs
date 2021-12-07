namespace CronParser
{
    public static class Vars
    {
        public static class UnixCronParser
        {
            public const string CronDelimiter = " ";
            public const int ExpectedNumberOfCronParts = 6;
        }

        public static class RegX
        {
            private static class Core
            {
                public const string Constant = "[0-9]+";
                public const string List = Constant + "(\\," + Constant + ")*";
                public const string Range = Constant + "-" + Constant;
                public const string MultiRange = Range + "(\\," + Range + ")*";
                public const string RangeWithStep = Constant + "-" + Constant + "/" + Constant;
                public const string Wildcard = "\\*";
                public const string WildcardWithStep = "\\*/" + Constant;
            }

            public const string Constant = "^" + Core.Constant + "$";
            public const string List = "^" + Core.List + "$";
            public const string Range = "^" + Core.Range + "$";
            public const string MultiRange = "^" + Core.MultiRange + "$";
            public const string RangeWithStep = "^" + Core.RangeWithStep + "$";
            public const string Wildcard = "^" + Core.Wildcard + "$";
            public const string WildcardWithStep = "^" + Core.WildcardWithStep + "$";

            private const string Generic = "^(" + Core.Constant + "|" + Core.List + "|" + Core.Range + "|" + Core.RangeWithStep
                + "|" + Core.MultiRange + "|" + Core.Wildcard + "|" + Core.WildcardWithStep + ")$";

            public const string Minute = Generic;

            public const string Hour = Generic;

            public const string DayOfMonth = Generic;

            public const string Month = Generic;

            public const string DayOfWeek = Generic;

            public const string Command = "^[a-zA-Z0-9/.]*$";
        }
    }
}
