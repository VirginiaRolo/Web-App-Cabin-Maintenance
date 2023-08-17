using Hotel.LogicaAccesoDatos.SqlRepositorios;
using Hotel.LogicaAplicacion.CasosDeUso.CabaniaUC;
using Hotel.LogicaAplicacion.CasosDeUso.MantenimientoUC;
using Hotel.LogicaAplicacion.CasosDeUso.TipoCabaniaUC;
using Hotel.LogicaAplicacion.CasosDeUso.UsuarioUC;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.ICabaniaUC;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.IMantenimientoUC;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.ITipoCabaniaUC;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.IUsuarioUC;
using Hotel.LogicaNegocio.Interfaces;
using Hotel.WebAPI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var rutaArchivo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Hotel.WebAPI.xml");
builder.Services.AddSwaggerGen(opciones =>
{
    //Se agrega la opcion de autenticarse en Swagger
    opciones.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
    {
        Description = "Autorizacion estandar mediante esquema Bearer",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    opciones.OperationFilter<SecurityRequirementsOperationFilter>();

    opciones.IncludeXmlComments(rutaArchivo);
    opciones.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Documentación de HotelCabanias.Api",
        Description = "Aqui se encuentran todos los endpoint activos para utilizar los servicios del proyecto HotelCabanias",
        Contact = new OpenApiContact
        {
            Email = "lolamora@email.com"
        },
        Version = "v1"

    });
});

//Configurar la autenticación
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer
  (opciones =>
{
    opciones.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
        .GetBytes(builder.Configuration.GetSection("AppSettings:SecretTokenKey").Value!)),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

// Configurar la autorización
builder.Services.AddAuthorization(opciones =>
{
    opciones.DefaultPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
});

#region SINGLETON
//TIPO CABANIA
builder.Services.AddScoped<IRepositorioTipoCabania, SqlRepositorioTipoCabania>();
//Casos de uso
builder.Services.AddScoped<IGetTiposDeCabaniaUC, GetTiposDeCabaniaUC>();
builder.Services.AddScoped<ICreateTipoCabaniaUC, CreateTipoCabaniaUC>();
builder.Services.AddScoped<IGetTiposDeCabaniaByNombreUC, GetTiposDeCabaniaByNombreUC>();
builder.Services.AddScoped<IGetUnTipoDeCabaniaByNombreUC, GetUnTipoDeCabaniaByNombreUC>();
builder.Services.AddScoped<IDeleteTipoCabaniaUC, DeleteTipoCabaniaUC>();
builder.Services.AddScoped<IEditTipoCabaniaUC, EditTipoCabaniaUC>();

//CABANIA
builder.Services.AddScoped<IRepositorioCabania, SqlRepositorioCabania>();
//Casos de uso
builder.Services.AddScoped<IGetCabaniasUC, GetCabaniasUC>();
builder.Services.AddScoped<ICreateCabaniaUC, CreateCabaniaUC>();
builder.Services.AddScoped<IGetCabaniasByCantMaxPersonasUC, GetCabaniasByCantMaxPersonasUC>();
builder.Services.AddScoped<IGetCabaniasHabilitadasParaReservaUC, GetCabaniasHabilitadasParaReservaUC>();
builder.Services.AddScoped<IGetCabaniasByNombreUC, GetCabaniasByNombreUC>();
builder.Services.AddScoped<IGetCabaniasByTipoUC, GetCabaniasByTipoUC>();
builder.Services.AddScoped<IGetUnaCabaniaByIdUC, GetUnaCabaniaByIdUC>();
builder.Services.AddScoped<IGetCabaniasByMontoUC, GetCabaniasByMontoUC>();

//MANTENIMIENTO
builder.Services.AddScoped<IRepositorioMantenimiento, SqlRepositorioMantenimiento>();
//Casos de uso
builder.Services.AddScoped<ICreateMantenimientoUC, CreateMantenimientoUC>();
builder.Services.AddScoped<IGetMantenimientosByCabaniaIdUC, GetMantenimientosByCabaniaIdUC>();
builder.Services.AddScoped<IGetMantenimientosByCabaniaIdYDosFechasUC, GetMantenimientosByCabaniaIdYDosFechasUC>();
builder.Services.AddScoped<IGetMantenimientosByCabaniaRangoUC, GetMantenimientosByCabaniaRangoUC>();

//USUARIO
builder.Services.AddScoped<IRepositorioUsuario, SqlRepositorioUsuario>();
builder.Services.AddScoped<IGetUsuarioUC, GetUsuarioUC>();

//CONFIGURACION
builder.Services.AddScoped<IRepositorioConfiguracion, SqlRepositorioConfiguracion>();

//ManejadorJwt
builder.Services.AddScoped<ManejadorJwt>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Autorización y Autenticación
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
