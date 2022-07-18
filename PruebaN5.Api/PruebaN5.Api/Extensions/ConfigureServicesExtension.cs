using Microsoft.EntityFrameworkCore;
using PruebaN5.APPLICATION.AppService;
using PruebaN5.APPLICATION.Interfaces;
using PruebaN5.DOMAIN.Interfaces;
using PruebaN5.INFRASTRUCTURE.REPOSITORY.SQLSERVER;
using PruebaN5.INFRASTRUCTURE.REPOSITORY.SQLSERVER.Repositorys;

namespace PruebaN5.Api.Extensions
{
    public static class ConfigureServicesExtension
    {
        public static IServiceCollection AddServices( this IServiceCollection services)
        {
            IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPermisoAppService, PermisoAppService>();

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddCors(policy =>
            {
                policy.AddPolicy("AllowAll", builder =>
                {
                    builder
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod();
                });
            });
            services.AddDbContext<N5DBContext>(options => options.UseSqlServer(configuration["DBConnectionString"]));
            return services;
        }
        public static WebApplication UseServices(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseCors("AllowAll");

            return app;
        }
    }
}
