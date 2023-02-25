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

// Creo que llamar al repositorio esta de sobra y creo que es una falla a la proteccion del DAL
builder.Services.AddScoped<IGenericRepository<OrdenCompra>, GenericRepository<OrdenCompra>>();

builder.Services.AddScoped<IOrdenCompraService, OrdenCompraService>();

builder.Services.AddScoped<IGenericRepository<Salida>, GenericRepository<Salida>>();
builder.Services.AddScoped<ISalidaService, SalidaService>();

builder.Services.AddScoped<IGenericRepository<LineaSalida>, GenericRepository<LineaSalida>>();
builder.Services.AddScoped<ILineaSalidaService, LineaSalidaService>();

builder.Services.AddScoped<IGenericRepository<Producto>, GenericRepository<Producto>>();
builder.Services.AddScoped<IProductoService, ProductoService>();

builder.Services.AddScoped<IGenericRepository<Existencia>, GenericRepository<Existencia>>();
builder.Services.AddScoped<IExistenciaService, ExistenciaService>();

builder.Services.AddScoped<IGenericRepository<Bodega>, GenericRepository<Bodega>>();
builder.Services.AddScoped<IBodegaService, BodegaService>();

builder.Services.AddScoped<IGenericRepository<Motivo>, GenericRepository<Motivo>>();
builder.Services.AddScoped<IMotivoService, MotivoService>();

builder.Services.AddScoped<IGenericRepository<Requisicion>, GenericRepository<Requisicion>>();
builder.Services.AddScoped<IRequisicionService, RequisicionService>();


// Inyeccion de dependencia
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
