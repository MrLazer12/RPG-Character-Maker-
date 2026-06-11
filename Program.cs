using Microsoft.EntityFrameworkCore;
using rpg_character.Data;
using rpg_character.Endpoints;
using rpg_character.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddCors();

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// endpoints registration
app.RegisterCharacterMappingEndpoints();
app.RegisterSkillsMappingEndpoints();

app.Run();