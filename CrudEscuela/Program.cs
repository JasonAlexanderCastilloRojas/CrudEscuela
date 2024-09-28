using CrudEscuela.Application.Interface.Persistence;
using CrudEscuela.Application.Interface.UseCases;
using CrudEscuela.Application.UseCases;
using CrudEscuela.Infraestructure.Data;
using CrudEscuela.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddJsonFile("appsettings.json");
var tokenKey = builder.Configuration.GetSection("token").GetSection("KeyToken").ToString();
var tokenBytes = Encoding.UTF8.GetBytes(tokenKey);
builder.Services.AddAuthentication(a =>
{
    a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(a =>
{
    a.RequireHttpsMetadata = false;
    a.SaveToken = true;
    a.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(tokenBytes),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IStudentApplication, StudentApplication>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ISubjectApplication, SubjectApplication>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IStudentSubjectApplication, StudentSubjectApplication>();
builder.Services.AddScoped<IStudentSubjectRepository, StudentSubjectRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();