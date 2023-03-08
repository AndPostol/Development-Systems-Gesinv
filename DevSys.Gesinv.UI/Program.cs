using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.DAL.DataContext;
using DevSys.Gesinv.DAL.Repositories;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Logic.Services;
using Microsoft.EntityFrameworkCore;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.DAL.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

builder.Services.AddScoped<IReporteRepository, ReporteRepository>();




// Services 
builder.Services.AddScoped<IOrdenCompraService, OrdenCompraService>();
builder.Services.AddScoped<ICondicionPagoService, CondicionPagoService>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<ILineaCompraService, LineaCompraService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<IBodegaService, BodegaService>();

builder.Services.AddScoped<IReporteService, ReporteService>();





//Inyencción de dependencias
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();

builder.Services.AddScoped<IGenericRepository<Linea>, GenericRepository<Linea>>();
builder.Services.AddScoped<ILineaService, LineaService>();

builder.Services.AddScoped<IGenericRepository<Marca>, GenericRepository<Marca>>();
builder.Services.AddScoped<IMarcaService, MarcaService>();

builder.Services.AddScoped<IColorProductoRepository, ColorProductoRepository>();
builder.Services.AddScoped<IColorProductoService, ColorProductoService>();

builder.Services.AddScoped<IGenericRepository<Tipo>, GenericRepository<Tipo>>();
builder.Services.AddScoped<ITipoService, TipoService>();

builder.Services.AddScoped<IGenericRepository<Grupo>, GenericRepository<Grupo>>();
builder.Services.AddScoped<IGrupoService, GrupoService>();

builder.Services.AddScoped<IGenericRepository<Bodega>, GenericRepository<Bodega>>();
builder.Services.AddScoped<IBodegaService, BodegaService>();

builder.Services.AddScoped<IGenericRepository<Medida>, GenericRepository<Medida>>();
builder.Services.AddScoped<IMedidaService, MedidaService>();

builder.Services.AddScoped<IGenericRepository<Color>, GenericRepository<Color>>();
builder.Services.AddScoped<IColorService, ColorService>();




//Conexión a la base de datos
builder.Services.AddDbContext<DbInventarioContext>(options =>
{
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"));
});
builder.Services.Configure<ConfigurationConnection>(builder.Configuration.GetSection("ConnectionStrings"));

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
