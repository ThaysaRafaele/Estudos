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
                new Pessoa (new DateTime(2021, 07, 06), "Fulano", "055.057.011-08"),
                new Pessoa (new DateTime(1997, 12, 16), "Ciclano", "064.245.010-29"),
                new Pessoa (new DateTime(2000, 06, 18), "Beltrano", "494.768.520-46")
            };

            Constante.ListaCardapio = new List<Cardapio>()
            {
                new Cardapio("Pizza", "Frango Cremoso", "Mussarela, Frango Desfiado, Requeijão e Orégano", "Média", 16.50, true),
                new Cardapio("Pizza", "Toscana", "Mussarela, Calabresa Moída, Pimentão, Bacon, Cebola e Orégano", "Grande", 30.00, false),
                new Cardapio("Pizza", "Portuguesa", "Mussarela, Presunto, Ovo, Pimentão, Tomate, Cebola e Orégano", "Grande", 26.00, true),
                new Cardapio("Pizza", "Romeu e Julieta", "Creme de Leite, Goiabada e Mussarela", "Pequena", 15.00, true),
                new Cardapio("Pizza", "Banana", "Creme de Leite, Banana Nanica, Açúcar Com Canela e Mussarela","Pequena", 15.00, true),
                new Cardapio("Bebida", "Coca-cola", "Lata","300 ml", 3.50, true),
                new Cardapio("Bebida", "Coca-cola", "Pet","2 L", 7.50, true),
                new Cardapio("Bebida", "Suco", "Laranja Natural","300 ml", 5.50, true)
            };
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
            .WithOrigins("*", "http://localhost:4200", "http://localhost:61777/")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
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
