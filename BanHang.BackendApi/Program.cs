using BanHang.Data.EF;
using Microsoft.EntityFrameworkCore;
using Utilities.Constants;

var builder = WebApplication.CreateBuilder(args);
//kết nối db SQL server
builder.Services.AddDbContext<BanHangDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString(SystemConstants.MainConnectionString)));

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();