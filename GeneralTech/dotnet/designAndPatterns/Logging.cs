// this one implement singletone logger using a concarrentQueue
// singleTone is better then Static when for implementing an interface and (can be use for DI)
using System;
using System.IO;

public class FileLogger : ILogger
{
    private readonly string _filePath;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void Log(string message)
    {
        File.AppendAllText(_filePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
    }
}
public interface ILogger
{
    void Log(string message);
}
public class DatabaseLogger : ILogger
{
    // Simulate database logging
    public void Log(string message)
    {
        // Code to log message to a database
        Console.WriteLine($"Logged to database: {message}");
    }
}

using System.Collections.Concurrent;
using System.Threading.Tasks;

public class Logger
{
    private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());
    private readonly ConcurrentQueue<string> _messageQueue = new ConcurrentQueue<string>();
    private readonly ILogger _logger;
    private readonly Task _logTask;

    private Logger()
    {
        // Choose the logger implementation (FileLogger or DatabaseLogger) // here factory method can be helpfull
        _logger = new FileLogger("log.txt");

        // Start the logging task
        // the Task.Run is because of the while loop Task.Ran alocate a thread our of the thread pool this will serve as long as the program lives 
        // when it is a long operation that requier a thread to be active for long then Task.Run is the way to go 
        // when running a specific task we can use await that will not get a thread out of the pool 
        // but instead will free the current thread to execute other tasks and once the task is done come back to it 
        _logTask = Task.Run(ProcessQueue);
    }

    public static Logger Instance => _instance.Value;

    public void Log(string message)
    {
        _messageQueue.Enqueue(message);
    }

    private async Task ProcessQueue()
    {
        while (true)
        {
            if (_messageQueue.TryDequeue(out var message))
            {
                _logger.Log(message);
            }
            await Task.Delay(100); // Adjust delay as needed
        }
    }
}
// Usage Example


class Program
{
    static void Main()
    {
        var logger = Logger.Instance;

        // Simulate logging messages
        for (int i = 0; i < 100; i++)
        {
            logger.Log($"Message {i}");
        }

        // Keep the application running to process the queue
        Console.ReadLine();
    }
    private void f()
    {
        private readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());
    public static readonly Instance => _instance.Value;
    }
}
/*
Explanation
ILogger Interface: Defines a contract for logging implementations.
FileLogger and DatabaseLogger: Implement the ILogger interface for different logging targets.
Logger Class: Implements the Singleton pattern and uses a ConcurrentQueue to handle logging messages. The ProcessQueue method runs in a background task to process messages asynchronously.
Usage Example: Demonstrates how to use the Logger class to log messages.
This setup ensures that the logger can handle a heavy load of messages efficiently and can be easily extended to support different logging targets.
*/