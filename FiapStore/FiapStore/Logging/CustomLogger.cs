namespace FiapStore.Logging;

public class CustomLogger : ILogger
{
    private readonly string _name;
    private readonly CustomLoggerProviderConfiguration _loggerConfig;
    public CustomLogger(string name, CustomLoggerProviderConfiguration loggerConfig)
    {
        _name = name;
        _loggerConfig = loggerConfig;
    }


    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        var message = string.Format($"{logLevel}: {eventId} - {formatter(state, exception)}");

        WriteTextOnFile(message);
    }

    private void WriteTextOnFile(string message)
    {
        var filePath = $@"C:\Users\mnsantos4\Desktop\fiap\FiapStore\FiapStore\FiapStore\bin\LOG-{DateTime.Now:yyyy-MM-dd}.txt";

        if (!File.Exists(filePath))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.Create(filePath).Dispose();
        }

        using StreamWriter sw = new StreamWriter(filePath, true);
        sw.WriteLine(message);
        sw.Close();
    }
}