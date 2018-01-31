using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrimeiroEF.Dados;

namespace PrimeiroEF
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //colocando as dependências para usar o Entity Framework e o padrão MVC
            services.AddDbContext<ClienteContexto>(opt => opt.UseInMemoryDatabase("ClientesDB"));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //usar o MVC
            app.UseMvc();

            //opcional, pode ser excluido
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Você saiu da rota!");
            });
        }
    }
}
