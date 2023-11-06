using AutoMapper;
using BookManagementAPI.DataBase;
using BookManagementAPI.Implementation;
using BookManagementAPI.MappingProfiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQL Server config
builder.Services.AddDbContext<BooksDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BooksContext")));

// Mapper config
var mapperConfig = new MapperConfiguration(config => config.AddProfile(new MainProfile()));
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Dependency injection
builder.Services.AddScoped<BookManager, BookManager>();
builder.Services.AddScoped<CategoryManager, CategoryManager>();

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
