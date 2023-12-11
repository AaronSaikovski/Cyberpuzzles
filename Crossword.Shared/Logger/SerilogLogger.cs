using Serilog;


namespace Crossword.Shared.Logger;

/// <summary>
/// Implements logging via Serilog
/// </summary>
public class SerilogLogger : ILoggerService
{
    private readonly ILogger _logger;

    public SerilogLogger()
    {
        _logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console() // Configuring console sink
            .CreateLogger();
    }
    
    /// <summary>
    /// LogInformation
    /// </summary>
    /// <param name="message"></param>
    public void LogInformation(string message)
    {
        _logger.Information(message);
    }

    /// <summary>
    /// LogWarning
    /// </summary>
    /// <param name="message"></param>
    public void LogWarning(string message)
    {
        _logger.Warning(message);
        
    }

    /// <summary>
    /// LogError
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    public void LogError(Exception ex, string message)
    {
        _logger.Error(ex, message);
    }

    /// <summary>
    /// LogVerbose
    /// </summary>
    /// <param name="message"></param>
    public void LogVerbose(Exception ex, string message)
    {
        _logger.Verbose(ex, message);
    }
}