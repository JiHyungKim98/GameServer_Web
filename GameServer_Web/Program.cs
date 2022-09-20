using GameServer_Web.Repository;
using GameServer_Web.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IAccountService, AccountService>();
builder.Services.AddSingleton<IRankingService, RankingService>();
builder.Services.AddSingleton<IRankingRepository, RankingByMemory>();
builder.Services.AddSingleton<IAccountRepository, AccountByMemory>();

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
