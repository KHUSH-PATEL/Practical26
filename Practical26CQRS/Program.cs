using DataAccessLayer.CQRS;
using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using DataAccessLayer.Mapping;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(opt => opt.AddProfile<MappingProfile>());

builder.Services.AddScoped<IEmployeeCommandRepository, EmployeeCommandRepository>();
builder.Services.AddScoped<IEmployeeCommand, EmployeeCommand>();
builder.Services.AddScoped<IEmployeeQueryRepository, EmployeeQueryRepository>();
builder.Services.AddScoped<IEmployeeQuery, EmployeeQuery>();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

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
