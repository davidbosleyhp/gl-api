using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using gl_api.Controllers;
using gl_api.Data;


// var configuration = new ConfigurationBuilder()
//     .AddEnvironmentVariables()
//     .AddCommandLine(args)
//     .AddJsonFile("appsettings.json")
//     .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration(builder =>
    {
        // builder.Sources.Clear();
        // builder.AddConfiguration(configuration);
        builder.AddEnvironmentVariables();
    });

builder.Logging.AddConsole();


// builder.Logging.AddJsonConsole(options =>
// {
//     options.IncludeScopes = false;
//     options.TimestampFormat = "yyyy:MM:dd hh:mm:ss ";
//     options.JsonWriterOptions = new JsonWriterOptions
//     {
//         // sometimes useful to change this to true when testing locally.
//         // but it needs to be false for Fluent Bit to
//         // process log lines correctly
//         Indented = false
//     };
// });




// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(
    o =>
        o.AddPolicy(
            "developmentOrigin",
            builder =>
            {
                // builder.WithOrigins("https://localhost:3000")
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }
        )
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISiteData, SiteData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();


//}

// app.UseHttpsRedirection();

// app.UseAuthorization();

app.UseCors("developmentOrigin");

app.MapControllers();

app.Logger.LogInformation($"GL API Starting...version " + app.Configuration["APP_VERSION"]);
    //FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location));

app.Run();
