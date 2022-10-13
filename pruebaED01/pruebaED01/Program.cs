using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using pruebaED01.Midleware;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//CONFIGURANDO LA SECCIÓN DE CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "mis origenes",
                      builder =>
                      {
                          builder.AllowAnyMethod();/// GET POST PUT DELETE PATCH 
                          builder.AllowAnyOrigin();/// Localhost/misitio.com/ linio.com
                          builder.AllowAnyHeader();/// recibir todos los headers enviar ==> jwt / usuario/password / basic token base 64

                      });
});

//CONFIGURAR EL METODO DE AUTENTICACIÓN CON JWT

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});






builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware(typeof(ErrorMidleware));
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors(x =>
{
    x.AllowAnyHeader();
    x.AllowAnyOrigin();
    x.AllowAnyMethod();
});

app.Run();
