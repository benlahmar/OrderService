using Microsoft.EntityFrameworkCore;
using Order.Domain.Iterfaces;
using Order.Infrastructure;
using Order.Infrastructure.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conf = builder.Configuration.AddJsonFile("appsettings.json").Build();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer(conf.GetConnectionString("orderconn"),
        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));


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