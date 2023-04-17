using DatingApp.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>( opt =>
{
    var sqlStringConn = builder.Configuration.GetConnectionString("DefaultConnection");
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}); 

var app = builder.Build();

app.MapControllers();

app.Run();
