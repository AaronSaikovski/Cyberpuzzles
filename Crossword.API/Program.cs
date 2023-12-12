using Crossword.API;
using Crossword.Shared.Logger;
using Crossword.Shared.Config;


//Init the logger and get the active config
var _logger = new SerilogLogger(ConfigurationHelper.ActiveConfiguration);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseMiddleware<ApiKeyMiddleware>();


#region getcrosswordpuzzledata
app.MapGet("/getcrosswordpuzzledata", (IConfiguration configuration) =>
{
    try
    {
        _logger.LogInformation("getcrosswordpuzzledata() API called");

        //Call GetCrosswordPuzzleData
        return PuzzleData.GetCrosswordPuzzleData(configuration["DatafilePath"]);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, ex.Message);
        return null;
    }

}).WithName("GetCrosswordPuzzleData");
#endregion

app.Run();
