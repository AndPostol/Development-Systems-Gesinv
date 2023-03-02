using DevSys.Gesinv.DAL;
using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.DAL.DataContext;
using DevSys.Gesinv.DAL.Repositories;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Logic.Services;
using Microsoft.EntityFrameworkCore;
using DevSys.Gesinv.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Servicios del Modulo de Orden Compra

// Repositories
builder.Services.AddScoped<IOrdenCompraRepository, OrdenCompraRepository>();
builder.Services.AddScoped<IGenericRepository<CondicionPago>, GenericRepository<CondicionPago>>();
builder.Services.AddScoped<IGenericRepository<Departamento>, GenericRepository<Departamento>>();
builder.Services.AddScoped<IGenericRepository<LineaCompra>, GenericRepository<LineaCompra>>();
builder.Services.AddScoped<IGenericRepository<Producto>, GenericRepository<Producto>>();
builder.Services.AddScoped<IGenericRepository<Proveedor>, GenericRepository<Proveedor>>();
builder.Services.AddScoped<IGenericRepository<Bodega>, GenericRepository<Bodega>>();




// Services 
builder.Services.AddScoped<IOrdenCompraService, OrdenCompraService>();
builder.Services.AddScoped<ICondicionPagoService, CondicionPagoService>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<ILineaCompraService, LineaCompraService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<IBodegaService, BodegaService>();




builder.Services.AddDbContext<DbInventarioContext>(options =>
{
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"));
});

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
