using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Project_Api.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Config Migrations on Project https://docs.microsoft.com/pt-br/ef/core/cli/powershell
// that link teach what package you need to install to work the migrations commands

// This link will show how to ser the DbContext and set a localDb as default to use the migration 
// https://stackoverflow.com/questions/70022021/net-6-uses-ef-core-to-migrate
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProjectApiDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Swagger Demo Documentation",
            Version = "v1"
        });

    options.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// If you would like to use ReDoc and Swagger when running the application in production, simply copy the code from the if statement checking if
// the app is running in debug mode and paste it below the if statement
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo Documentation v1"));

    app.UseReDoc(options =>
    {
        options.DocumentTitle = "Swagger Demo Documentation";
        options.SpecUrl = "/swagger/v1/swagger.json";
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// This is the tutorial that I fallowed https://christian-schou.dk/how-to-make-api-documentation-using-swagger/
// it has how to implement ReDoc into project and how to cofigure it
// Also Shows how to implement some details in endPoints, like descriptions and a Sumary
