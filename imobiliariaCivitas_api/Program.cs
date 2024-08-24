using imobiliariaCivitas_api.Data;
using imobiliariaCivitas_api.Services;
using Microsoft.EntityFrameworkCore;

namespace imobiliariaCivitas_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ImobiliariaServices>();
            ConfigureService(builder);

            var app = builder.Build();

            
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();





            void ConfigureService(WebApplicationBuilder builder)
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            }
        }
    }


}
