using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SalesDatePrediction.Api.Helpers.Filters;
using SalesDatePrediction.Core;
using SalesDatePrediction.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Custom Exception Filter
builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(CustomExceptionFilterAttribute));
});

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", p =>
        p.AllowAnyHeader()
         .AllowAnyMethod()
         .AllowAnyOrigin()
         .WithExposedHeaders()
    );
});

// Configurar los servicios Core e Infraestructura
builder.Services.AddCore(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

// AutoMapper configuration (AddMappings)
builder.Services.AddMappings();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Enable CORS with the defined policy
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
