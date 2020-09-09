using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MiPrimeraApi.Infrastructure;
using MiPrimeraApi.Mapper;
using MiPrimeraApi.Repository;
using MiPrimeraApi.Repository.IRepository;

namespace MiPrimeraApi
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
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<ITipoRepository, TipoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddAutoMapper(typeof(UsuarioMapper));
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:TokenKey").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAutoMapper(typeof(CategoriaMapper));
            services.AddDbContext<CatalogoDbContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("CatalogosApi", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Pokeapi",
                    Description = "Contiene las descripciones de pokemon",
                    Version = "1.0",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Email = "adominguez@axsistec.com",
                        Name = "Soporte tecnico a desarrollador",
                        Url = new Uri("https://axsistecnologia.com")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "BSD",
                        Url = new Uri("https://bsd.axsistec.com")
                    }

               

            });

                var XMLComentarios = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var APIRutaComentarios = Path.Combine(AppContext.BaseDirectory, XMLComentarios);
                options.IncludeXmlComments(APIRutaComentarios);
            });
            services.AddControllers();
        }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();


        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/CatalogosApi/swagger.json", "CatalogoCategoriaAPI");
                //options.SwaggerEndpoint("/ApiCatalogos/swagger/CatalogoCategoriaAPI/swagger.json", "Catalogos generales API");
                //options.SwaggerEndpoint("/ApiCatalogos/swagger/APIUsuariosCatalogo/swagger.json", "API Usuarios catalogo");
                options.RoutePrefix = "";
        });
        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
}
