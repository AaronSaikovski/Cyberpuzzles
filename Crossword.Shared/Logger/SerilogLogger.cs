using Serilog;
using Microsoft.Extensions.Configuration;

namespace Crossword.Shared.Logger;

/// <summary>
/// Implements logging via Serilog
/// </summary>
public class SerilogLogger : ILoggerService, IDisposable, IAsyncDisposable
{
    private readonly Serilog.Core.Logger _logger;
    private bool _disposed;

    /// <summary>
    /// Pass in Appsettings config
    /// </summary>
    /// <param name="configuration"></param>
    public SerilogLogger(IConfiguration configuration)
    {
        _logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration) // Load configuration settings
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
    /// <param name="ex"></param>
    /// <param name="message"></param>
    public void LogVerbose(Exception ex, string message)
    {
        _logger.Verbose(ex, message);
    }

    /// <summary>
    /// fatal
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    public void LogFatal(Exception ex, string message)
    {
        _logger.Fatal(ex, message);
    }

    /// <summary>
    /// Synchronous cleanup - disposes the logger synchronously
    /// </summary>
    public void Dispose()
    {
        if (_disposed) return;

        _logger.Dispose();
        _disposed = true;
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Asynchronous cleanup - disposes the logger asynchronously
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        if (_disposed) return;

        await _logger.DisposeAsync();
        _disposed = true;
        GC.SuppressFinalize(this);
    }

}