using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZooAPI.Domain.IRepository;
using ZooAPI.Domain.Models;
using ZooAPI.Infrastructure.Data;
using ZooAPI.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IZooKeeperRepository, ZooKeeperRepository>();
builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
builder.Services.AddTransient<IAnimalKeeperRepository, AnimalKeeperRepository>();

//builder.Services.AddMediatR(typeof(CreateAccountCommand).GetTypeInfo().Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ZooDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DockerConnection"));
    });

builder.Services.AddStackExchangeRedisCache(
    options =>
    {
        options.Configuration = builder.Configuration.GetConnectionString("Redis");
        options.InstanceName = "ZooAPI_";
    });

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
