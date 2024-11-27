using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace Cultura_New
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //для автоматического создания экземпляра контекста базы при каждом вызове/запуске
            builder.Services.AddDbContext<Cultura_bdContext>(
                options=>options.UseSqlServer(
                    "Server=DESKTOP-HD64L82;Database=TestDb;User Id=AdminLogin;Password=12345;"));
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
            });


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
