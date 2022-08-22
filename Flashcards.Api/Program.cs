using Flashcards.Dal.Context;
using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;
using Flashcards.Service.DataServices;
using Flashcards.Dal.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FlashcardDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddTransient<DbContext, FlashcardDbContext>();

// Services Injection
builder.Services.AddScoped<IFlashcardService<Deck>, DeckService>();


// Repositories Injection
builder.Services.AddScoped<IFlashcardsRepository<Deck>, DeckRepository>();

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
