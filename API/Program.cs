using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using API.Interfaces;
using API.Services;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using API.Extentions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// EXTENTIONS FROM APPLICATION
 builder.Services.AddApplicationServices(builder.Configuration);
 builder.Services.AddIdentityService(builder.Configuration);


var app = builder.Build();
builder.Services.AddCors();

// Configure the HTTP request pipeline.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();