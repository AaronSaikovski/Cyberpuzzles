using CrosswordData;
using CrosswordParser;

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
    // get datafile path
    var puzzleDataFile = configuration["DatafilePath"];

    //check for null data file result
    if (puzzleDataFile is null) return null;
    
    //get the data file
    var fileResult = ParserHelper.GetRandomDataFile(puzzleDataFile);
    return fileResult;
}).WithName("GetCrosswordPuzzleData");
#endregion

app.Run();
