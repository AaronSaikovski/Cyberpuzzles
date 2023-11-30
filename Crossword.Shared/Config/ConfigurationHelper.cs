

using Microsoft.Extensions.Configuration;

namespace CyberPuzzles.Shared.Config;

public static class ConfigurationHelper
{
    //IConfigurationRoot

    public static string? DataApiUrl { get; }
    public static string? DataApiKey { get; }

    #region ConfigurationHelper
    /// <summary>
    /// Config helper
    /// </summary>
    static ConfigurationHelper()
    {
        try
        {
            //Load config
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.dev.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            //Data API URL
            DataApiUrl = configuration.GetSection("DataAPISvc")["Url"];
        
            //Auth Key
            DataApiKey = configuration.GetSection("DataAPISvc")["XApiKey"];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    #endregion
    
  
  
}