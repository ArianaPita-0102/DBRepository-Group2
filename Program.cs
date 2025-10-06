using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DBRepository_Group2.Data.AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));


//scoped solo para db externo y singleton para db en memoria

builder.Services.AddScoped<DBRepository_Group2.Repositories.IGuestRepository, DBRepository_Group2.Repositories.GuestRepository>();
builder.Services.AddScoped<DBRepository_Group2.Services.IGuestService, DBRepository_Group2.Services.GuestService>();

var app = builder.Build();
// Dependency Injection


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


