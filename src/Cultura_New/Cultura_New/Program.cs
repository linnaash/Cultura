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
            //��� ��������������� �������� ���������� ��������� ���� ��� ������ ������/�������
            builder.Services.AddDbContext<Cultura_bdContext>(
                options=>options.UseSqlServer(
                    "Server=DESKTOP-HD64L82;Database=TestDb;User Id=AdminLogin;Password=12345;"));
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
