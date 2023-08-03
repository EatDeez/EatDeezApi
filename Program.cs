using Microsoft.EntityFrameworkCore;
using ZelpApi.Models;
using Microsoft.Extensions.Configuration;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// https://www.youtube.com/watch?v=I8p8j5MuMAo

var keyVaultURI = new Uri(builder.Configuration.GetSection("KeyVaultURI").Value!);

// you need to be logged in to Azure for this to work, via azure cli or visual studio
// test
var azureCredential = new DefaultAzureCredential();

// Adds our secrets from Key Vault to the configuration
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
