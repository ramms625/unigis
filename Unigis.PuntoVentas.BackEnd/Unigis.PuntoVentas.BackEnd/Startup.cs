using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Unigis.PuntoVentas.BackEnd.Data;
using Unigis.PuntoVentas.BackEnd.Data.DataInicial;
using Unigis.PuntoVentas.BackEnd.Data.Models;
using Unigis.PuntoVentas.BackEnd.Filtros;

namespace Unigis.PuntoVentas.BackEnd
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }




        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
                .ConfigureApiBehaviorOptions(o =>
                {
                    o.InvalidModelStateResponseFactory = (errorContext) =>
                    {
                        var errors = new List<string>();
                        var fields = errorContext.ModelState.Values.ToList();

                        foreach (var field in fields)
                        {
                            foreach (var error in field.Errors)
                                errors.Add(error.ErrorMessage);
                        }

                        var result = new ApiResponse<List<string>>(errors, "Campo(s) incorrecto(s).");
                        return new BadRequestObjectResult(result);
                    };
                });

            
            
            services
                .AddSwaggerGen(o =>
                {
                    o.SwaggerDoc("v1", new OpenApiInfo { Title = "UNIGIS - punto de ventas", Version = "v1" });
                    o.EnableAnnotations();
                });



            services
                .AddDbContext<ApplicationDbContext>(options =>
                {
                    var connectionString = _configuration.GetConnectionString("ConnectionString");
                    options.UseSqlServer(connectionString);
                });



            services.AddCors(options =>
            {
                options.AddPolicy("UNIGIS_React", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });



            services.AddAutoMapper(typeof(Startup));

            services.AddEndpointsApiExplorer();

            services.AddDataProtection();

            services.AddScoped<IDataInicial, DataInicial>();

            services.AddScoped(typeof(FiltroExisteRecurso<>));

            services.AddScoped<EjecucionQueries>();
        }



        public void Configure(WebApplication app)
        {
            InsercionDataInicial(app);

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI(o => o.SwaggerEndpoint("/swagger/v1/swagger.json", "UNIGIS - punto de ventas"));
            }

            app.UseCors("UNIGIS_React");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }


        static void InsercionDataInicial(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var insercion = scope.ServiceProvider.GetRequiredService<IDataInicial>();
                insercion.InsercionDatos().GetAwaiter().GetResult();
            }
        }
    }
}