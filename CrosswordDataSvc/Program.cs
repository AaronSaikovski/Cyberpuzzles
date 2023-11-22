using CyberPuzzles.Crossword.Parsers;

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


//getcrosswordpuzzledata
app.MapGet("/getcrosswordpuzzledata", () =>
    {
        using (ConfigurationManager configuration = builder.Configuration)
        {
            // get datafile path
            var puzzleDataFile= configuration["DatafilePath"];
        
            //check for null data file result
            if (puzzleDataFile != null)
            {
                //get the data file
                var fileResult = Helpers.GetRandomDataFile(puzzleDataFile);
                return fileResult;
            }

            return null;
        }
    })
    .WithName("GetCrosswordPuzzleData");

app.Run();
