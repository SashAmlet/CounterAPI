using CounterAPI.Context;
using CounterAPI.Models;
using CounterAPI.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = $"Data Source={dbHost}; Initial Catalog={dbName}; User ID=sa; Password={dbPassword};Persist Security Info=True; Encrypt=False";

builder.Services.AddDbContext<CounterAPIContext>(option => option.UseSqlServer(
    connectionString
    /*builder.Configuration.GetConnectionString("DefaultConnection")*/
    ));
builder.Services.AddDbContext<PageItemsContext>(option => option.UseSqlServer(
    connectionString
    /*builder.Configuration.GetConnectionString("DefaultConnection")*/
    ));
builder.Services.AddScoped<IRepository<User, CounterAPIContext>,Repository<User, CounterAPIContext>>();
builder.Services.AddScoped<IRepository<LanguageList, CounterAPIContext>, Repository<LanguageList, CounterAPIContext>>();
builder.Services.AddScoped<IRepository<ThemeList, CounterAPIContext>, Repository<ThemeList, CounterAPIContext>>();
builder.Services.AddScoped<IRepository<TemplateList, CounterAPIContext>, Repository<TemplateList, CounterAPIContext>>();
builder.Services.AddScoped<IRepository<PageItem, PageItemsContext>, Repository<PageItem, PageItemsContext>>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}); ;

builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
