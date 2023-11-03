using Microsoft.OpenApi.Models;
using senac.projetoIntegrador.Authentication;
using senac.projetoIntegrador.Domain.Repositories;
using senac.projetoIntegrador.Repositories.EmMemoria;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "apiProjetoIntegrador", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = @"JWT Authorization header using the Bearer scheme.
                   \r\n\r\n Enter 'Bearer'[space] and then your token in the text input below.
                    \r\n\r\nExample: Bearer 12345abcdef",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
});

string policyCors = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyCors,
                      policy =>
                      {
                          policy
                          .AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      });
});

JwtSettings settings = builder.Configuration
    .GetSection("JwtToken")
    .Get<JwtSettings>();

ConfigureJwt configure =
    new ConfigureJwt(settings);

//Registra as dependências
builder.Services.AddSingleton<JwtSettings>(settings);
builder.Services.AddSingleton<ConfigureJwt>(configure);
builder.Services.AddSingleton<IProdutoRepository, ProdutoRepository>();
builder.Services.AddSingleton<IPedidoRepository, PedidoRepository>();

//Adiciona os serviços de autenticação JWT
configure.ConfigureJwtMethod(builder.Services);

//Builda o Contâiner
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(policyCors);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
