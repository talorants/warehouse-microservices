using Microsoft.EntityFrameworkCore;
using Talorants.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
  
var app = builder.Build();
 
app.Run();
