using imobiliariaCivitas_api.Data;
using imobiliariaCivitas_api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace imobiliariaCivitas_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfiguracaoAutenticacao(builder);

            // Adiciona o serviço de CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy => policy.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());
            });

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            configuracaoSwaggerGen(builder);
            builder.Services.AddScoped<ImobiliariaServices>();
            ConfigureService(builder);

            var app = builder.Build();

            // Ativa o CORS usando a política configurada
            app.UseCors("AllowAll");

            app.UseAuthentication();  // Adiciona o middleware de autenticação
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();

            void ConfigureService(WebApplicationBuilder builder)
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            }

            void ConfiguracaoAutenticacao(WebApplicationBuilder builder)
            {
                var jwtSettings = builder.Configuration.GetSection("JwtSettings");

                builder.Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings["Issuer"],
                        ValidAudience = jwtSettings["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });

                builder.Services.AddAuthorization();
            }

            void configuracaoSwaggerGen(WebApplicationBuilder builder)
            {
                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Imobiliaria API", Version = "v1" });

                    // Configuração do JWT para Swagger
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Insira o token JWT desta forma: {seu token}"
                    });

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });
                });
            }
        }
    }
}
