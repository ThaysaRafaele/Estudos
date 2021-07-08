using Crud.Api.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            Constante.ListaPessoas = new List<Pessoa>()
            {
                //Nome = "Fulano",
                //Nasc = new DateTime(2021, 07, 06),
                //CPF = "055.057.011-08"
                new Pessoa {Nasc=new DateTime(2021, 07, 06), Nome = "Fulano", CPF = "055.057.011-08"},
                new Pessoa {Nasc=new DateTime(1997, 12, 16), Nome = "Ciclano", CPF = "064.245.010-29"},
                new Pessoa {Nasc=new DateTime(2000, 06, 18), Nome = "Beltrano", CPF = "494.768.520-46"}
            };
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
