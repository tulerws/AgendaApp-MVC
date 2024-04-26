using AgendaApp.API.Configurations;
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Domain.Interfaces.Services;
using AgendaApp.Domain.Services;
using AgendaApp.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
SwaggerConfiguration.Configure(builder.Services);
CorsConfiguration.Configure(builder.Services);
JwtBearerConfiguration.Configure(builder.Services);

builder.Services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
builder.Services.AddTransient<ITarefaDomainService, TarefaDomainService>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<ITarefaRepository, TarefaRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors(CorsConfiguration.PolicyName);
app.Run();

public partial class Program { }



