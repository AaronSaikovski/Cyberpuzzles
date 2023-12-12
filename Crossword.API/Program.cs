using Crossword.API;
using Crossword.Shared.Logger;

//Init the logger
var _logger = new SerilogLogger();

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
    _logger.LogInformation("getcrosswordpuzzledata() API called");

    //Call GetCrosswordPuzzleData
    return PuzzleData.GetCrosswordPuzzleData(configuration["DatafilePath"]);


}).WithName("GetCrosswordPuzzleData");
#endregion

app.Run();
