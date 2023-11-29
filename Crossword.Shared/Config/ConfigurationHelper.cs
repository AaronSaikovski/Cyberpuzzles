

using Microsoft.Extensions.Configuration;

namespace CyberPuzzles.Shared;

public static class ConfigurationHelper
{
    //IConfigurationRoot
    private static IConfigurationRoot _configuration;
    
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
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.dev.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
    
            //Data API URL
            DataApiUrl = _configuration.GetSection("DataAPISvc")["Url"];
        
            //Auth Key
            DataApiKey = _configuration.GetSection("DataAPISvc")["XApiKey"];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    #endregion
    
  
  
}