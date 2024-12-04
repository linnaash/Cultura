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
            //��� ��������������� �������� ���������� ��������� ���� ��� ������ ������/�������
            builder.Services.AddDbContext<Cultura_bdContext>(
                options => options.UseSqlServer(builder.Configuration["CONNECTION_STRING"]));
            //Scoped ��������, ��� ���� ��������� ������� ����� �������������� �� ������ HTTP-������. ��� ������, ������ ���
            //����������� ����� �������� � ����� ���������� ���� ������, ������� ������ ���� "�����������" � �������� ������
            //�������.
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "API ���������� ������������� � ���������� �������",
                    Description = "API ��� ���������� �������������, ��������� � ��������� � ���������� �������.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "������� ��������� API",
                        Url = new Uri("https://example.com/support")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "�������� �� ������������� API",
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
                var context = services.GetRequiredService<Cultura_bdContext>();
                context.Database.Migrate();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                    options.RoutePrefix = string.Empty; // ��� ������ Swagger ��������� �� ������ /
                });
                app.UseCors(builder => builder.WithOrigins(new[] { "https://localhost:7214", })
                 .AllowAnyHeader()
                 .AllowAnyMethod());


                app.UseHttpsRedirection();

                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            }
        }
    }
}
