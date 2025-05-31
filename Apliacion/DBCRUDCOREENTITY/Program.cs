using Microsoft.EntityFrameworkCore;
using DBCRUDCOREENTITY.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// se inyecta la dadena de conexion
builder.Services.AddDbContext<DbcrudcoreentityContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("conexionSQL")) );
//para que se actualice el navegador en tiempo real
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
