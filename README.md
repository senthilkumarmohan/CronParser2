# CronParser
Console app to validate/parse cron expressions.

CronParserBase: 
--------------
- Base implementation of ICronParser interface. 
- Depends on individual cron part parsers to validate the cron expression/generate possible values.
- Expects the concrete class to implement IsValid, Parse, and Preprocess methods (e.g. UnixCronProcessor) - this allows us to 
	extend/create newer versions of cron processors.

CronPartParserBase:
------------------
- Base implementation of ICronPartParser interface.
- Uses regular expressions to validate the individual cron parts.
- Contains CronPartValueParserFactory. 
- As the values for the cron parts can be specified in different formats (e.g. list, range, list with step, etc.), this class 
	uses CronPartValueParserFactory to create suitable value parser for a cron part.

CronPartValueParsers:
--------------------
- These classes contain logic to genrate possible values based on the cron part value formats (e.g. list, range, list with step, etc.)


-----------------------------------------------------------------------------------
Please refer CronParser.cd class diagram for a quick overview of the class structure.
-----------------------------------------------------------------------------------
