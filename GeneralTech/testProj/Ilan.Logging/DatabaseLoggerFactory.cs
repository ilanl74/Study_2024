using System;

namespace Ilan.Logging;

public class DatabaseLoggerFactory : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
