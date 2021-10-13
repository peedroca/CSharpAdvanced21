using System;


namespace socket
{
    public static class LogExtension
    {
        public static void LogReceivedMessage(this string message, string host = null)
        {
            Console.WriteLine($"...: {host} Message Received >> {message}");
        }

        public static void LogError(this Exception exception)
        {
            Console.WriteLine($"...: Error >> {exception.Message}");
        }

    }
}