
using Crossword.API.Extensions;
using Crossword.API.Endpoints;
using Crossword.Shared.Logger;
using Crossword.Shared.Config;


//Init the logger and get the active config
var _logger = new SerilogLogger(ConfigurationHelper.ActiveConfiguration);

try
{
    //Ref: https://blog.treblle.com/how-to-structure-your-minimal-api-in-net/
    var builder = WebApplication.CreateBuilder(args);

    builder.RegisterServices();
    var app = builder.Build();
    app.RegisterMiddleware();
    app.RegisterCrosswordEndpoints();
    app.Run();
}
catch (Exception ex)
{
    _logger.LogFatal(ex, ex.Message);
}
finally
{
    _logger.Dispose();
}
