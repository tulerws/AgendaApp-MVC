using Microsoft.OpenApi.Models;

namespace AgendaApp.API.Configurations
{
    public class SwaggerConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options => options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "TarefasApp - API para agenda de tarefas",
                    Description = "API REST .NET com EntityFramework e XUnit",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "COTI Informática",
                        Email = "contato@cotiinformatica.com.br",
                        Url = new Uri("http://www.cotiinformatica.com.br")
                    }
                }));
        }
    }

}
