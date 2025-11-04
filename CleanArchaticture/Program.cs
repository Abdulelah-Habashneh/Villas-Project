using CleanArchaticture.Application.Common.Interfaces;
using CleanArchaticture.Domain.Model;
using CleanArchaticture.Infrastructure.Data;
using CleanArchaticture.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
// to link dbcontext with appsetting
builder.Services.AddDbContext<ApplicationDbContext>(option=> 
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
