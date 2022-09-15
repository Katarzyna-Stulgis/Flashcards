using Flashcards.Api.Middleware;
using Flashcards.Api.Validators;
using Flashcards.Dal.Context;
using Flashcards.Dal.Repositories;
using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models;
using Flashcards.Domain.Models.Entities;
using Flashcards.Service.DataServices;
using Flashcards.Service.Dtos;
using Flashcards.Service.Profiles;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FlashcardDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy(name: "FlashcardsOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddAutoMapper(
    typeof(Program),
    typeof(RegisterProfile),
    typeof(LoginProfile),
    typeof(DeckProfile)
    );


// DbContext
builder.Services.AddTransient<DbContext, FlashcardDbContext>();

var authenticationSettings = new AuthenticationSettings();
builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);

builder.Services.AddSingleton(authenticationSettings);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
    {
        cfg.RequireHttpsMetadata = false;
        cfg.SaveToken = true;
        cfg.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = authenticationSettings.JwtIssuer,
            ValidAudience = authenticationSettings.JwtIssuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
        };
    });

// Add fluentValidation
builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
builder.Services.AddScoped<IValidator<LoginDto>, LoginDtoValidator>();

// Services Injection
builder.Services.AddScoped<IFlashcardService<Deck>, DeckService>();
builder.Services.AddScoped<IFlashcardService<Flashcard>, FlashcardService>();
builder.Services.AddScoped<IFlashcardService<Folder>, FolderService>();
builder.Services.AddScoped<IFlashcardService<Role>, RoleService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// Repositories Injection
builder.Services.AddScoped<IFlashcardsRepository<Deck>, DeckRepository>();
builder.Services.AddScoped<IFlashcardsRepository<Flashcard>, FlashcardRepository>();
builder.Services.AddScoped<IFlashcardsRepository<Folder>, FolderRepository>();
builder.Services.AddScoped<IFlashcardsRepository<Role>, RoleRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository<FlashcardDbContext>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("FlashcardsOrigins");
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
