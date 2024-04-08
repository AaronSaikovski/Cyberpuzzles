using Microsoft.Extensions.Configuration;

namespace Crossword.Shared.Config;

/// <summary>
/// Configuration helper..reads from appsettings file per environment
/// </summary>
public static class ConfigurationHelper
{
    #region fields
    // API Url 
    public static string? DataApiUrl { get; }

    //API Key
    public static string? DataApiKey { get; }

    //Active Configuration
    public static IConfiguration ActiveConfiguration { get; }

    #endregion

    #region ConfigurationHelper
    /// <summary>
    /// Config helper
    /// </summary>
    static ConfigurationHelper()
    {
        //Toggle if DEBUG flag set
#if DEBUG

        //Load config - DEBUG
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.dev.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
#else
                       
                //Load config - RELEASE
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();
#endif


        //Set the active configuration
        ActiveConfiguration = configuration;

        //Data API URL
        DataApiUrl = configuration.GetSection("DataAPISvc")["Url"];

        //Auth Key
        DataApiKey = configuration.GetSection("DataAPISvc")["XApiKey"];
    }
    #endregion



}