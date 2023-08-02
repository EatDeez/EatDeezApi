using Microsoft.EntityFrameworkCore;
using EatDeezApi.Models;
using Microsoft.Extensions.Configuration;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var keyVaultURI = new Uri(builder.Configuration.GetSection("KeyVaultURI").Value!);

var azureCredential = new DefaultAzureCredential(); // you need to be logged in to Azure for this to work, via azure cli or visual studio

var cs = builder.Configuration.GetConnectionString(
    builder.Configuration.GetSection("ConnectionStrings").GetValue("Database", "null")!
);

builder.Configuration.AddAzureKeyVault(keyVaultURI, azureCredential);

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
