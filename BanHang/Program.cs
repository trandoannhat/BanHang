using BanHang.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
/// Đăng ký AppDbContext, sử dụng kết nối đến MS SQL Server
builder.Services.AddDbContext<BanHangDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("BanHangConnection")));
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();//đăng ký format code;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
         );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();