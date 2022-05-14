using System.Threading;

namespace ListRipper
{
    class Logging
    {
        private static int delay = 10;

        public static void LogWarning(string message)
        {
            FLSharp.PrintColor("[" + FLSharp.GetDateTime() + "]" + " Warning: " + message, "yellow");
            Thread.Sleep(delay);
        }
        public static void LogError(string message)
        {
            FLSharp.PrintColor("[" + FLSharp.GetDateTime() + "]" + " Error: " + message, "red");
            Thread.Sleep(delay);
        }
        public static void LogMessage(string message)
        {
            FLSharp.PrintColor("[" + FLSharp.GetDateTime() + "]" + " Console: " + message, "white");
            Thread.Sleep(delay);
        }
        public static void LogSuccess(string message)
        {
            FLSharp.PrintColor("[" + FLSharp.GetDateTime() + "]" + " Success: " + message, "green");
            Thread.Sleep(delay);
        }

        public static void LogSystem(string message)
        {
            FLSharp.PrintColor("[" + FLSharp.GetDateTime() + "]" + " System: " + message, "blue");
        }
    }
}
