using Hotel.LogicaAccesoDatos.SqlRepositorios;
using Hotel.LogicaNegocio.Interfaces;
using Microsoft.AspNetCore.Session;
using Hotel.LogicaAplicacion.CasosDeUso.TipoCabaniaUC;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.ITipoCabaniaUC;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.ICabaniaUC;
using Hotel.LogicaAplicacion.CasosDeUso.CabaniaUC;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.IMantenimientoUC;
using Hotel.LogicaAplicacion.CasosDeUso.MantenimientoUC;

namespace Hotel.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDistributedMemoryCache();

            #region SESSION
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(1200);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            #endregion

            #region SINGLETON
            //Tipo Cabania
            builder.Services.AddScoped<IRepositorioTipoCabania, SqlRepositorioTipoCabania>();
            //casos de uso
            builder.Services.AddScoped<IGetTiposDeCabaniaUC, GetTiposDeCabaniaUC>();
            builder.Services.AddScoped<ICreateTipoCabaniaUC, CreateTipoCabaniaUC>();
            builder.Services.AddScoped<IGetTiposDeCabaniaByNombreUC, GetTiposDeCabaniaByNombreUC>();
            builder.Services.AddScoped<IGetUnTipoDeCabaniaByNombreUC, GetUnTipoDeCabaniaByNombreUC>();
            builder.Services.AddScoped<IDeleteTipoCabaniaUC, DeleteTipoCabaniaUC>();
            builder.Services.AddScoped<IEditTipoCabaniaUC, EditTipoCabaniaUC>();

            //Cabania
            builder.Services.AddScoped<IRepositorioCabania, SqlRepositorioCabania>();
            //casos de uso
            builder.Services.AddScoped<IGetCabaniasUC, GetCabaniasUC>();
            builder.Services.AddScoped<ICreateCabaniaUC, CreateCabaniaUC>();
            builder.Services.AddScoped<IGetCabaniasByCantMaxPersonasUC, GetCabaniasByCantMaxPersonasUC>();
            builder.Services.AddScoped<IGetCabaniasHabilitadasParaReservaUC, GetCabaniasHabilitadasParaReservaUC>();
            builder.Services.AddScoped<IGetCabaniasByNombreUC, GetCabaniasByNombreUC>();
            builder.Services.AddScoped<IGetCabaniasByTipoUC, GetCabaniasByTipoUC>();
            builder.Services.AddScoped<IGetUnaCabaniaByIdUC, GetUnaCabaniaByIdUC>();

            //Mantenimiento
            builder.Services.AddScoped<IRepositorioMantenimiento, SqlRepositorioMantenimiento>();
            //casos de uso
            builder.Services.AddScoped<ICreateMantenimientoUC, CreateMantenimientoUC>();
            builder.Services.AddScoped<IGetMantenimientosByCabaniaIdUC, GetMantenimientosByCabaniaIdUC>();
            builder.Services.AddScoped<IGetMantenimientosByCabaniaIdYDosFechasUC, GetMantenimientosByCabaniaIdYDosFechasUC>();

            //Usuario
            builder.Services.AddScoped<IRepositorioUsuario, SqlRepositorioUsuario>();
            //Configuracion
            builder.Services.AddScoped<IRepositorioConfiguracion, SqlRepositorioConfiguracion>();
            #endregion

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

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            //pattern: "{controller=Cabania}/{action=GetByHabilitada}/{id?}");

            app.Run();
        }
    }
}