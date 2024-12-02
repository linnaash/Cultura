using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using System.Reflection;

namespace Cultura_New
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //для автоматического создания экземпляра контекста базы при каждом вызове/запуске
            builder.Services.AddDbContext<Cultura_bdContext>(
                options => options.UseSqlServer(builder.Configuration["CONNECTION_STRING"]));
            //Scoped означает, что один экземпляр объекта будет использоваться на каждый HTTP-запрос. Это удобно, потому что
            //репозитории часто работают с одним контекстом базы данных, который должен быть "разделяемым" в пределах одного
            //запроса.
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "API управления мероприятиями в культурных центрах",
                    Description = "API для управления мероприятиями, событиями и ресурсами в культурных центрах.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Команда поддержки API",
                        Url = new Uri("https://example.com/support")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "Лицензия на использование API",
                        Url = new Uri("https://example.com/license")
                    }
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
            
           
            

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context=services.GetRequiredService<Cultura_bdContext>();
                context.Database.Migrate();
            }
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(builder => builder
    .WithOrigins("https://localhost:7214")
    .AllowAnyHeader()
    .AllowAnyMethod());


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
