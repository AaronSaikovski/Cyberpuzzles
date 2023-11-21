var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

ConfigurationManager configuration = builder.Configuration;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//Map
app.MapGet("/getcrosswordpuzzledata", () =>
    {
        var fileResult = GetRandomDataFile();
        return fileResult;
    })
    .WithName("GetCrosswordPuzzleData");

app.Run();


//Read random data file contents from datafile path
string? GetRandomDataFile()
{
    // get datafile path
    var myKeyValue = configuration["DatafilePath"];

    if (myKeyValue != null)
    {
        // Get a list of all files in the folder
        var files = Directory.GetFiles(myKeyValue);

        // Check if there are any files in the folder
        if (files.Length > 0)
        {
            // Generate a random number to select a file
            var random = new Random();
            var randomIndex = random.Next(0, files.Length);

            // Get the randomly selected file path
            var selectedFilePath = files[randomIndex];

            // Read the contents of the selected file
            var fileContents = File.ReadAllText(selectedFilePath);
            return fileContents;
        }
    }

    return null;
}