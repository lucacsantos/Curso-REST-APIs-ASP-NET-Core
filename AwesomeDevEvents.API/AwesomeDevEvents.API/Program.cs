using AwesomeDevEvents.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DevEventsCs");

builder.Services.AddDbContext<DevEventsDbContext>(o => o.UseSqlite(connectionString));

//builder.Services.AddDbContext<DevEventsDbContext>(o => o.UseInMemoryDatabase("DevEventsDB"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AwesomeDevEvents.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Lucas Dev",
            Email = "lucasdev@email.com",
            Url = new Uri("https://www.linkedin.com/in/lucas-santos-866a76247/")
        }
    });

    var xmlFile = "AwesomeDevEvents.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
