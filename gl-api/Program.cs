using gl_api.Controllers;
using gl_api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(o => o.AddPolicy("developmentOrigin",
                builder=>
                {
                    // builder.WithOrigins("https://localhost:3000")
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                }
));

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


app.Run();
