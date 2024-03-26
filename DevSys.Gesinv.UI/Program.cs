using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.DAL.DataContext;
using DevSys.Gesinv.DAL.Repositories;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Logic.Services;
using Microsoft.EntityFrameworkCore;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.DAL.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Servicios del Modulo de Orden Compra


// Repositories
builder.Services.AddScoped<IOrdenCompraRepository, OrdenCompraRepository>();
builder.Services.AddScoped<IGenericRepository<CondicionPago>, GenericRepository<CondicionPago>>();
builder.Services.AddScoped<IGenericRepository<Departamento>, GenericRepository<Departamento>>();
builder.Services.AddScoped<IGenericRepository<LineaCompra>, GenericRepository<LineaCompra>>();
builder.Services.AddScoped<IGenericRepository<Proveedor>, GenericRepository<Proveedor>>();
builder.Services.AddScoped<IReporteRepository, ReporteRepository>();
builder.Services.AddScoped<IGenericRepository<Empresa>, GenericRepository<Empresa>>();
builder.Services.AddScoped<IGenericRepository<TipoProveedor>, GenericRepository<TipoProveedor>>();
builder.Services.AddScoped<IGenericRepository<Estado>, GenericRepository<Estado>>();
builder.Services.AddScoped<IGenericRepository<Provincia>, GenericRepository<Provincia>>();
builder.Services.AddScoped<IGenericRepository<TipoPersona>, GenericRepository<TipoPersona>>();
builder.Services.AddScoped<IGenericRepository<Usuario>, GenericRepository<Usuario>>();
//builder.Services.AddScoped<IGenericRepository<Ingreso>, GenericRepository<Ingreso>>();
builder.Services.AddScoped<IIngresoRepository, IngresoRepository>();




// Services 
builder.Services.AddScoped<IOrdenCompraService, OrdenCompraService>();
builder.Services.AddScoped<ICondicionPagoService, CondicionPagoService>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<ILineaCompraService, LineaCompraService>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<IReporteService, ReporteService>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<ITipoProveedorService, TipoProveedorService>();
builder.Services.AddScoped<IEstadoService, EstadoService>();
builder.Services.AddScoped<IProvinciaService, ProvinciaService>();
builder.Services.AddScoped<ITipoPersonaService, TipoPersonaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();


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

builder.Services.AddScoped<ISalidaRepository, SalidaRepository>();
builder.Services.AddScoped<ISalidaService, SalidaService>();

builder.Services.AddScoped<IGenericRepository<LineaSalida>, GenericRepository<LineaSalida>>();
builder.Services.AddScoped<ILineaSalidaService, LineaSalidaService>();

builder.Services.AddScoped<IGenericRepository<Existencia>, GenericRepository<Existencia>>();
builder.Services.AddScoped<IExistenciaService, ExistenciaService>();

builder.Services.AddScoped<IGenericRepository<Bodega>, GenericRepository<Bodega>>();
builder.Services.AddScoped<IBodegaService, BodegaService>();
builder.Services.AddScoped<IIngresoService, IngresoService>();

builder.Services.AddScoped<IGenericRepository<Medida>, GenericRepository<Medida>>();
builder.Services.AddScoped<IMedidaService, MedidaService>();

builder.Services.AddScoped<IGenericRepository<Color>, GenericRepository<Color>>();
builder.Services.AddScoped<IColorService, ColorService>();

builder.Services.AddScoped<IGenericRepository<Motivo>, GenericRepository<Motivo>>();
builder.Services.AddScoped<IMotivoService, MotivoService>();


// Inyeccion de dependencia
builder.Services.AddDbContext<DbInventarioContext>(options =>
{
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"));
});
builder.Services.Configure<ConfigurationConnection>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Acceso/IniciarSesion";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

builder.Services.AddControllersWithViews(options => {
    options.Filters.Add(
            new ResponseCacheAttribute
            {
                NoStore = true,
                Location = ResponseCacheLocation.None,
            }
        );
});
var app = builder.Build();

var filesql = "../Docs/Insert-Data.sql";
var sql = await File.ReadAllTextAsync(filesql);

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DbInventarioContext>();
    dbContext.Database.Migrate();
    dbContext.Database.ExecuteSqlRaw(sql);
}

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

app.UseAuthentication();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
