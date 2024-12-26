using BusinessLogic.Authorization;
using BusinessLogic.Helpers;
using BusinessLogic.Services;
using Cultura_New.Authorization;
using Cultura_New.Helpers;
using DataAccess.Wrapper;
using Domain.Interfaces;
using DataAccess.Models;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.Text.Json.Serialization;
using DataAccess.Models;


namespace Cultura_New
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //��� ��������������� �������� ���������� ��������� ���� ��� ������ ������ / �������

            builder.Services.AddDbContext<Cultura_bdNewContext>(options =>
     options.UseSqlServer("Server=DESKTOP-E1QR638;Database=Cultura_bdNew;User Id=sa;Password=12345;"));


            //// configure strongly typed settings object
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

            ////Scoped ��������, ��� ���� ��������� ������� ����� �������������� �� ������ HTTP-������. ��� ������, ������ ���
            ////����������� ����� �������� � ����� ���������� ���� ������, ������� ������ ���� "�����������" � �������� ������
            ////�������.
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            // configure DI for application services
            builder.Services.AddScoped<IJwtUtils, JwtUtils>();
            builder.Services.AddScoped<IAccountService, AccountsService>();
            builder.Services.AddScoped<IEmailService, EmailService>();

            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            builder.Services.AddSingleton(typeAdapterConfig);
            builder.Services.AddSingleton(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                return configuration.GetSection("AppSettings").Get<AppSettings>();
            });

            builder.Services.AddControllers();
            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                //serialize enums as strings in api responses (e.g. Role)
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddMapster();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API ���������� ������������� � ���������� �������",
                    Description = "API ��� ���������� �������������, ��������� � ��������� � ���������� �������.",
                    Contact = new OpenApiContact
                    {
                        Name = "������� ��������� API",
                        Url = new Uri("https://example.com/support")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "�������� �� ������������� API",
                        Url = new Uri("https://example.com/license")
                    }
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme.\r\n\r\n
                                  Enter 'Bearer' [space] and then your token in the text input below.
                                  \r\n\r\nExample: 'Bearer' 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    },
                                    Scheme = "oauth2",
                                    Name = "Bearer",
                                    In = ParameterLocation.Header,
                                },
                                    new List<string>()
                            }
            });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });



            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<Cultura_bdNewContext>();
                await context.Database.MigrateAsync();
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                app.UseCors(builder => builder.WithOrigins(new[] { "https://clientforculturawebapi-y5bxc2o4.b4a.run" })
                 .AllowAnyHeader()
                 .AllowAnyMethod());



                app.UseHttpsRedirection();

                //global error handler
                app.UseMiddleware<ErrorHandlerMiddleware>();

                //custom jwt auth middleware
                app.UseMiddleware<JwtMiddleware>();

                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            }
        }
    }
}
