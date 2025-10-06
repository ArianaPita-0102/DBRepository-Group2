using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DBRepository_Group2.Data.AppDBContext>(opt =>
opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<DBRepository_Group2.Services.IEventService, DBRepository_Group2.Services.EventService>();
builder.Services.AddScoped<DBRepository_Group2.Repositories.IEventRepository, DBRepository_Group2.Repositories.EventRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
