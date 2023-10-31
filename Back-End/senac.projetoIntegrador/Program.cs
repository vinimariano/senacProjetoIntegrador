using Microsoft.Extensions.Configuration;
using senac.projetoIntegrador.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

JwtSettings settings = builder.Configuration
    .GetSection("JwtToken")
    .Get<JwtSettings>();

ConfigureJwt configure = 
    new ConfigureJwt(settings);

builder.Services.AddSingleton<JwtSettings>(settings);
builder.Services.AddSingleton<ConfigureJwt>(configure);

configure.ConfigureJwtMethod(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options =>
    options.WithOrigins(settings.Issuer)
    .AllowAnyMethod().AllowAnyHeader()
    );

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
