namespace GameDataParser.Logging
{
    class Logger<T> where T : Exception, new()
    {
        public static string ExceptionString { get; set; } = "";
        public static T ex = new();

        public static void BuildExceptionToWrite(T ex)
        {
            ExceptionString = @$"
[{DateTime.Now}] - {ex.Message} Stack trace: {ex}
================================= EXCEPTION END =================================";
        }

        public static void Log(T jsonException)
        {
            string logsPath = "./error.txt";

            File.AppendAllText(logsPath, ExceptionString);

            Logger<T>.BuildExceptionToWrite(jsonException);
            File.AppendAllText(logsPath, ExceptionString);
        }
    }
}