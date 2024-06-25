using UTN.Inc.Business;
using UTN.Inc.Data.Repository;
using Microsoft.EntityFrameworkCore;
using UTN.Inc.Data.DBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UtnincContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UTN.Connection")));

builder.Services.AddScoped<UsuarioLogica>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<ProductoLogica>();
builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<UtnincContext>();
builder.Services.AddScoped<CompraRepository>();
builder.Services.AddScoped<CompraLogica>();
builder.Services.AddScoped<VentaRepository>();
builder.Services.AddScoped<VentaLogica>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
